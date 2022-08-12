using AlloyAdvanced.Models.Media;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.Blobs;
using EPiServer.PlugIn;
using EPiServer.Scheduler;
using Lucene.Net.Store;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web.Configuration;

namespace AlloyAdvanced.Business.ScheduledJobs
{
    [ScheduledPlugIn(DisplayName = "ImportImages", GUID = "364F1215-8286-4DF0-8679-9AA14990021C", SortIndex = -1, Restartable = true)]
    public class ImportImages : ScheduledJobBase
    {
        private bool _stopSignaled;
        public const string ScheduledJobName = "Import Images";

        private readonly string[] patterns = new[] { "*.jpeg", "*.png", "*.jpg" };

        private readonly IContentRepository contentRepository;
        private readonly IBlobFactory blobFactory;

        public ImportImages()
        {
            IsStoppable = true;
        }

        public ImportImages(IContentRepository repo, IBlobFactory blob) : this()
        {
            contentRepository = repo;
            blobFactory = blob;
        }

        /// <summary>
        /// Called when a user clicks on Stop for a manually started job, or when ASP.NET shuts down.
        /// </summary>
        public override void Stop()
        {
            _stopSignaled = true;
        }

        /// <summary>
        /// Called when a scheduled job executes
        /// </summary>
        /// <returns>A status message to be stored in the database log and visible from admin mode</returns>
        public override string Execute()
        {
            var toImportFolder = WebConfigurationManager.AppSettings["episerver:edu.ToImportFolder"];
            var importedFolder = WebConfigurationManager.AppSettings["episerver:edu.ImportedFolder"];

            var assetsFolder = new ContentReference(WebConfigurationManager.AppSettings["episerver:edu.ImportAssetsFolder"]);

            var images = GetImageFilenames(toImportFolder);

            var toImportCount = images.Count();
            var importedCount = 0;
            var remainingToImportCount = toImportCount;

            //Call OnStatusChanged to periodically notify progress of job for manually started jobs
            OnStatusChanged($"Starting execution of {ScheduledJobName}, {toImportCount} images to import.");

            while (remainingToImportCount > 0)
            {

                //For long running jobs periodically check if stop is signaled and if so stop execution
                if (_stopSignaled)
                {
                    return "Stop of job was called";
                }

                var nextImage = images.First();
                var asset = contentRepository.GetDefault<ImageFile>(assetsFolder);

                asset.Name = Path.GetFileName(nextImage);
                asset.Copyright = "copyright";

                var blob = blobFactory.CreateBlob(asset.BinaryDataContainer, Path.GetExtension(nextImage));

                blob.WriteAllBytes(File.ReadAllBytes(nextImage));

                asset.BinaryData = blob;

                contentRepository.Save(asset, EPiServer.DataAccess.SaveAction.Publish, EPiServer.Security.AccessLevel.NoAccess);

                File.Move(nextImage,
                    Path.Combine(importedFolder, Path.GetFileName(nextImage))
                    );

                Thread.Sleep(2500);

                importedCount++;

                OnStatusChanged($"Execution of {ScheduledJobName} ongoing, {remainingToImportCount} please wait...");

                images = GetImageFilenames(toImportFolder);

                remainingToImportCount = images.Count();

            }

            return $"Imported {importedCount}";
        }

        private IEnumerable<string> GetImageFilenames(string path)
        {
            IEnumerable<string> files = null;

            foreach (var pattern in patterns)
            {
                var moreFiles = System.IO.Directory.GetFiles(path, pattern);

                if (files == null)
                {
                    files = moreFiles;
                }
                else
                {
                    files = files.Concat(moreFiles);
                }
            }

            return files;
        }
    }
}
