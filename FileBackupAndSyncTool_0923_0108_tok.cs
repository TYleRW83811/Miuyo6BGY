// 代码生成时间: 2025-09-23 01:08:37
using System;
using System.IO;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
# TODO: 优化性能
using CommunityToolkit.Mvvm.Input;

namespace FileBackupAndSyncTool
{
    public class FileBackupAndSyncToolViewModel : ObservableObject
    {
# 添加错误处理
        private string sourcePath;
        private string targetPath;
        private bool isSyncing;
        private string syncStatus;

        [ObservableProperty]
        public string SourcePath { get => sourcePath; set => SetProperty(ref sourcePath, value); }

        [ObservableProperty]
        public string TargetPath { get => targetPath; set => SetProperty(ref targetPath, value); }

        [ObservableProperty]
        public bool IsSyncing { get => isSyncing; set => SetProperty(ref isSyncing, value, onChanged: UpdateSyncStatus); }
# 扩展功能模块

        [ObservableProperty]
        public string SyncStatus { get => syncStatus; set => SetProperty(ref syncStatus, value); }

        public FileBackupAndSyncToolViewModel()
        {
        }

        [RelayCommand]
        public async Task BackupAndSync()
        {
# 扩展功能模块
            try
            {
# NOTE: 重要实现细节
                IsSyncing = true;
                SyncStatus = "Starting sync...";

                await Task.Run(() => SyncFiles());
            }
            catch (Exception ex)
            {
# NOTE: 重要实现细节
                SyncStatus = $"Error: {ex.Message}";
            }
            finally
            {
                IsSyncing = false;
            }
        }

        private void SyncFiles()
# 添加错误处理
        {
            if (string.IsNullOrEmpty(SourcePath) || string.IsNullOrEmpty(TargetPath))
            {
                SyncStatus = "Source or target path is not set.";
                return;
            }
# TODO: 优化性能

            var sourceDirectory = new DirectoryInfo(SourcePath);
            var targetDirectory = new DirectoryInfo(TargetPath);

            if (!sourceDirectory.Exists)
# 优化算法效率
            {
                SyncStatus = "Source directory does not exist.";
                return;
            }

            if (!targetDirectory.Exists)
            {
                targetDirectory.Create();
            }

            foreach (var file in sourceDirectory.GetFiles())
            {
# NOTE: 重要实现细节
                var targetFile = new FileInfo(Path.Combine(targetDirectory.FullName, file.Name));
                file.CopyTo(targetFile.FullName, true);
            }

            SyncStatus = "Sync completed successfully.";
        }
# NOTE: 重要实现细节

        private void UpdateSyncStatus(bool newValue)
# 改进用户体验
        {
            if (!newValue)
            {
                SyncStatus = "Sync is not running.";
            }
        }
    }
}
