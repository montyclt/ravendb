using System;
using System.Collections.Generic;
using System.Linq;
using Sparrow.Json.Parsing;

namespace Raven.Client.Server.PeriodicBackup
{
    public class PeriodicBackupStatus
    {
        public long TaskId { get; set; }

        public BackupType BackupType { get; set; }

        public string NodeTag { get; set; }

        public DateTime? LastFullBackup { get; set; }

        public DateTime? LastIncrementalBackup { get; set; }

        public LocalBackup LocalBackup { get; set; }

        public UploadToS3 UploadToS3 { get; set; }

        public UploadToGlacier UploadToGlacier { get; set; }

        public UploadToAzure UploadToAzure { get; set; }

        public long? LastEtag { get; set; }

        public long? DurationInMs { get; set; }

        public DynamicJsonValue ToJson()
        {
            var json = new DynamicJsonValue();
            UpdateJson(json);
            return json;
        }

        public void UpdateJson(DynamicJsonValue json)
        {
            json[nameof(TaskId)] = TaskId;
            json[nameof(BackupType)] = BackupType;
            json[nameof(NodeTag)] = NodeTag;
            json[nameof(LastFullBackup)] = LastFullBackup;
            json[nameof(LastIncrementalBackup)] = LastIncrementalBackup;
            json[nameof(LocalBackup)] = LocalBackup?.ToJson();
            json[nameof(UploadToS3)] = UploadToS3?.ToJson();
            json[nameof(UploadToGlacier)] = UploadToGlacier?.ToJson();
            json[nameof(UploadToAzure)] = UploadToAzure?.ToJson();
            json[nameof(LastEtag)] = LastEtag;
            json[nameof(DurationInMs)] = DurationInMs;
        }

        public static string GenerateItemName(string databaseName, long taskId)
        {
            return $"periodic-backups/{databaseName}/{taskId}";
        }
    }
}