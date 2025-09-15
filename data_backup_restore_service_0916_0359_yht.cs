// 代码生成时间: 2025-09-16 03:59:41
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataBackupRestoreService
{
    // DataBackupRestoreService 是一个用于执行数据备份和恢复的服务类
    public class DataBackupRestoreService
    {
        private readonly string _backupDirectory;
        private readonly string _dataFile;

        // 构造函数
        // 初始化备份目录和数据文件路径
        public DataBackupRestoreService(string backupDirectory, string dataFile)
        {
            _backupDirectory = backupDirectory;
            _dataFile = dataFile;
        }

        // 备份数据
        // 使用异步方法来备份数据，提高性能
        public async Task BackupDataAsync()
        {
            var backupPath = Path.Combine(_backupDirectory, $