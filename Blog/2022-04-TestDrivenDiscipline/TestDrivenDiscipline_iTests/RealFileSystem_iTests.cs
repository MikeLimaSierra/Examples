using System;
using System.Collections.Generic;
using System.IO;

using Nuclear.TestSite;

using TestDrivenDiscipline.Contracts;

using FileSystem = TestDrivenDiscipline.RealFileSystem;

namespace TestDrivenDiscipline_iTests {
    class RealFileSystem_iTests : IDisposable {

        #region Context

        [TestMethod]
        void ContextIsNotIsolated() {

            IFileSystem fs1 = new FileSystem();
            IFileSystem fs2 = new FileSystem();
            FileInfo file = new FileInfo(Path.Combine(_tempDir.FullName, "MyFile.txt"));

            fs1.Create(file);

            Test.If.Value.IsTrue(fs1.Exists(file));
            Test.If.Value.IsTrue(fs2.Exists(file));

        }

        #endregion

        #region CreateFile

        [TestMethod]
        [TestData(nameof(File_Data))]
        void CreateNotExistingFile(String subPath) {

            IFileSystem sut = new FileSystem();
            FileInfo file = new FileInfo(Path.Combine(_tempDir.FullName, subPath));
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.Create(file), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsTrue(sut.Exists(file));
            Test.If.Value.IsTrue(sut.Exists(file.Directory));

        }

        [TestMethod]
        void CreateExistingFile() {

            IFileSystem sut = new FileSystem();
            FileInfo file = new FileInfo(Path.Combine(_tempDir.FullName, "MyFile.txt"));
            sut.Create(file);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.Create(file), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsTrue(sut.Exists(file));

        }

        #endregion

        #region CreateDir

        [TestMethod]
        [TestData(nameof(Dir_Data))]
        void CreateNotExistingDir(String subPath) {

            IFileSystem sut = new FileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, subPath));
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.Create(dir), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsTrue(sut.Exists(dir));
            Test.If.Value.IsTrue(sut.Exists(dir.Parent));

        }

        [TestMethod]
        void CreateExistingDir() {

            IFileSystem sut = new FileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            sut.Create(dir);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.Create(dir), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsTrue(sut.Exists(dir));

        }

        #endregion

        #region DeleteFile

        [TestMethod]
        [TestData(nameof(File_Data))]
        void DeleteNotExistingFile(String subPath) {

            IFileSystem sut = new FileSystem();
            FileInfo file = new FileInfo(Path.Combine(_tempDir.FullName, subPath));
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.Delete(file), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsFalse(sut.Exists(file));

        }

        [TestMethod]
        void DeleteExistingFile() {

            IFileSystem sut = new FileSystem();
            FileInfo file = new FileInfo(Path.Combine(_tempDir.FullName, "MyFile.txt"));
            sut.Create(file);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.Delete(file), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsFalse(sut.Exists(file));
            Test.If.Value.IsTrue(sut.Exists(file.Directory));

        }

        #endregion

        #region DeleteDir

        [TestMethod]
        [TestData(nameof(Dir_Data))]
        void DeleteNotExistingDir(String subPath) {

            IFileSystem sut = new FileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, subPath));
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.Delete(dir), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsFalse(sut.Exists(dir));

        }

        [TestMethod]
        void DeleteExistingDir() {

            IFileSystem sut = new FileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            sut.Create(dir);
            DirectoryInfo subDir = new DirectoryInfo(Path.Combine(dir.FullName, "MySubDir"));
            sut.Create(subDir);
            FileInfo file = new FileInfo(Path.Combine(dir.FullName, "MyFile.txt"));
            sut.Create(file);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.Delete(dir), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsFalse(sut.Exists(dir));
            Test.If.Value.IsFalse(sut.Exists(subDir));
            Test.If.Value.IsFalse(sut.Exists(file));
            Test.If.Value.IsTrue(sut.Exists(dir.Parent));

        }

        #endregion

        #region ExistsFile

        [TestMethod]
        [TestData(nameof(File_Data))]
        void ExistsNotExistingFile(String subPath) {

            IFileSystem sut = new FileSystem();
            FileInfo file = new FileInfo(Path.Combine(_tempDir.FullName, subPath));
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.Exists(file), out Exception _);

            Test.If.Value.IsFalse(result);

        }

        [TestMethod]
        void ExistsExistingFile() {

            IFileSystem sut = new FileSystem();
            FileInfo file = new FileInfo(Path.Combine(_tempDir.FullName, "MyFile.txt"));
            sut.Create(file);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.Exists(file), out Exception _);

            Test.If.Value.IsTrue(result);

        }

        #endregion

        #region ExistsDir

        [TestMethod]
        [TestData(nameof(Dir_Data))]
        void ExistsNotExistingDir(String subPath) {

            IFileSystem sut = new FileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, subPath));
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.Exists(dir), out Exception _);

            Test.If.Value.IsFalse(result);

        }

        [TestMethod]
        void ExistsExistingDir() {

            IFileSystem sut = new FileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            Boolean result = default;
            sut.Create(dir);

            Test.IfNot.Action.ThrowsException(() => result = sut.Exists(dir), out Exception _);

            Test.If.Value.IsTrue(result);

        }

        #endregion

        #region EnumerateDirectories

        [TestMethod]
        [TestData(nameof(Dir_Data))]
        void EnumerateDirectoriesNotExisting(String subPath) {

            IFileSystem sut = new FileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, subPath));
            IEnumerable<DirectoryInfo> result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.EnumerateDirectories(dir), out Exception _);

            Test.If.Enumerable.IsEmpty(result);

        }

        [TestMethod]
        void EnumerateDirectoriesEmpty() {

            IFileSystem sut = new FileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            sut.Create(dir);
            IEnumerable<DirectoryInfo> result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.EnumerateDirectories(dir), out Exception _);

            Test.If.Enumerable.IsEmpty(result);

        }

        [TestMethod]
        void EnumerateDirectoriesExisting() {

            IFileSystem sut = new FileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            sut.Create(dir);
            DirectoryInfo subDir1 = new DirectoryInfo(Path.Combine(dir.FullName, "MySubDir1"));
            sut.Create(subDir1);
            DirectoryInfo subDir2 = new DirectoryInfo(Path.Combine(dir.FullName, "MySubDir2"));
            sut.Create(subDir2);
            FileInfo file1 = new FileInfo(Path.Combine(dir.FullName, "MyFile1.txt"));
            sut.Create(file1);
            FileInfo file2 = new FileInfo(Path.Combine(dir.FullName, "MyFile2.txt"));
            sut.Create(file2);
            IEnumerable<DirectoryInfo> result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.EnumerateDirectories(dir), out Exception _);

            Test.If.Enumerable.Contains(result, _ => _.FullName == subDir1.FullName);
            Test.If.Enumerable.Contains(result, _ => _.FullName == subDir2.FullName);
            Test.IfNot.Enumerable.Contains(result, _ => _.FullName == file1.FullName);
            Test.IfNot.Enumerable.Contains(result, _ => _.FullName == file2.FullName);

        }

        #endregion

        #region EnumerateFiles

        [TestMethod]
        [TestData(nameof(Dir_Data))]
        void EnumerateFilesNotExisting(String subPath) {

            IFileSystem sut = new FileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, subPath));
            IEnumerable<FileInfo> result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.EnumerateFiles(dir), out Exception _);

            Test.If.Enumerable.IsEmpty(result);

        }

        [TestMethod]
        void EnumerateFilesEmpty() {

            IFileSystem sut = new FileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            sut.Create(dir);
            IEnumerable<FileInfo> result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.EnumerateFiles(dir), out Exception _);

            Test.If.Enumerable.IsEmpty(result);

        }

        [TestMethod]
        void EnumerateFilesExisting() {

            IFileSystem sut = new FileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            sut.Create(dir);
            DirectoryInfo subDir1 = new DirectoryInfo(Path.Combine(dir.FullName, "MySubDir1"));
            sut.Create(subDir1);
            DirectoryInfo subDir2 = new DirectoryInfo(Path.Combine(dir.FullName, "MySubDir2"));
            sut.Create(subDir2);
            FileInfo file1 = new FileInfo(Path.Combine(dir.FullName, "MyFile1.txt"));
            sut.Create(file1);
            FileInfo file2 = new FileInfo(Path.Combine(dir.FullName, "MyFile2.txt"));
            sut.Create(file2);
            IEnumerable<FileInfo> result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.EnumerateFiles(dir), out Exception _);

            Test.IfNot.Enumerable.Contains(result, _ => _.FullName == subDir1.FullName);
            Test.IfNot.Enumerable.Contains(result, _ => _.FullName == subDir2.FullName);
            Test.If.Enumerable.Contains(result, _ => _.FullName == file1.FullName);
            Test.If.Enumerable.Contains(result, _ => _.FullName == file2.FullName);

        }

        #endregion

        #region data, setup & teardown

        internal DirectoryInfo _tempDir = new DirectoryInfo(Path.Combine(Path.GetTempPath(), $"ITESTS_{Guid.NewGuid()}"));

        private Boolean _disposedValue;

        public RealFileSystem_iTests() {
            _tempDir.Create();
        }

        protected virtual void Dispose(Boolean disposing) {
            if(!_disposedValue) {
                if(disposing) {
                    _tempDir?.Refresh();

                    if(_tempDir != null && _tempDir.Exists) {
                        _tempDir.Delete(true);
                    }

                    _tempDir = null;
                }
                _disposedValue = true;
            }
        }

        public void Dispose() {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        IEnumerable<Object[]> File_Data() {
            yield return new Object[] { "MyFile.txt" };
            yield return new Object[] { @"NotExisting\MyFile.txt" };
        }

        IEnumerable<Object[]> Dir_Data() {
            yield return new Object[] { "MyDir" };
            yield return new Object[] { @"NotExisting\MyDir" };
        }

        #endregion

    }
}
