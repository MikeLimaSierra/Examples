using System;
using System.Collections.Generic;
using System.IO;

using Nuclear.TestSite;

using TestDrivenDiscipline;
using TestDrivenDiscipline.Contracts;

using Directory = TestDrivenDiscipline.Directory;

namespace TestDrivenDiscipline_uTests {
    class Directory_uTests {

        #region ctors

        [TestMethod]
        void DefaultCtorThrows() {

            Test.If.Action.ThrowsException(() => new Directory(null), out ArgumentNullException ex);

            Test.If.Value.IsEqual(ex.ParamName, "directory");

        }

        [TestMethod]
        void DefaultCtor() {

            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            IDirectory sut = default;

            Test.IfNot.Action.ThrowsException(() => sut = new Directory(dir), out Exception _);

            Test.If.Object.IsOfExactType<RealFileSystem>(sut.FileSystem);
            Test.If.Value.IsEqual(sut.Name, dir.Name);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);
            Test.If.Value.IsEqual(sut.Parent.Path, dir.Parent.FullName);
            Test.If.Reference.IsEqual(sut.Parent.FileSystem, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Root.Path, dir.Root.FullName);
            Test.If.Reference.IsEqual(sut.Root.FileSystem, sut.FileSystem);

        }

        [TestMethod]
        void CustomCtorThrows() {

            Test.If.Action.ThrowsException(() => new Directory(new FakeFileSystem(), null), out ArgumentNullException ex);

            Test.If.Value.IsEqual(ex.ParamName, "directory");

        }

        [TestMethod]
        void CustomCtor() {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            IDirectory sut = default;

            Test.IfNot.Action.ThrowsException(() => sut = new Directory(fs, dir), out Exception _);

            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Name, dir.Name);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);
            Test.If.Value.IsEqual(sut.Parent.Path, dir.Parent.FullName);
            Test.If.Value.IsEqual(sut.Root.Path, dir.Root.FullName);

        }

        #endregion

        #region Exists

        [TestMethod]
        [TestData(nameof(Dir_Data))]
        void ExistsNotExisting(String subPath) {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, subPath));
            IDirectory sut = new Directory(fs, dir);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.Exists, out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);

        }

        [TestMethod]
        void ExistsExisting() {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            fs.Create(dir);
            IDirectory sut = new Directory(fs, dir);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.Exists, out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);
        }

        #endregion

        #region Create

        [TestMethod]
        [TestData(nameof(Dir_Data))]
        void CreateNotExisting(String subPath) {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, subPath));
            IDirectory sut = new Directory(fs, dir);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.Create(), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsTrue(fs.Exists(dir));
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);

        }

        [TestMethod]
        void CreateExisting() {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            fs.Create(dir);
            IDirectory sut = new Directory(fs, dir);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.Create(), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsTrue(fs.Exists(dir));
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);

        }

        #endregion

        #region Delete

        [TestMethod]
        [TestData(nameof(Dir_Data))]
        void DeleteNotExisting(String subPath) {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, subPath));
            IDirectory sut = new Directory(fs, dir);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.Delete(), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsFalse(fs.Exists(dir));
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);

        }

        [TestMethod]
        void DeleteExisting() {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            fs.Create(dir);
            DirectoryInfo subDir = new DirectoryInfo(Path.Combine(dir.FullName, "MySubDir"));
            fs.Create(subDir);
            FileInfo file = new FileInfo(Path.Combine(dir.FullName, "MyFile.txt"));
            fs.Create(file);
            IDirectory sut = new Directory(fs, dir);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.Delete(), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsFalse(fs.Exists(dir));
            Test.If.Value.IsFalse(fs.Exists(subDir));
            Test.If.Value.IsFalse(fs.Exists(file));
            Test.If.Value.IsTrue(fs.Exists(dir.Parent));
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);

        }

        #endregion

        #region EnumerateDirectories

        [TestMethod]
        [TestData(nameof(Dir_Data))]
        void EnumerateDirectoriesNotExisting(String subPath) {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, subPath));
            IDirectory sut = new Directory(fs, dir);
            IEnumerable<IDirectory> result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.EnumerateDirectories(), out Exception _);

            Test.If.Enumerable.IsEmpty(result);
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);

        }

        [TestMethod]
        void EnumerateDirectoriesEmpty() {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            fs.Create(dir);
            IDirectory sut = new Directory(fs, dir);
            IEnumerable<IDirectory> result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.EnumerateDirectories(), out Exception _);

            Test.If.Enumerable.IsEmpty(result);
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);

        }

        [TestMethod]
        void EnumerateDirectoriesExisting() {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            fs.Create(dir);
            DirectoryInfo subDir1 = new DirectoryInfo(Path.Combine(dir.FullName, "MySubDir1"));
            fs.Create(subDir1);
            DirectoryInfo subDir2 = new DirectoryInfo(Path.Combine(dir.FullName, "MySubDir2"));
            fs.Create(subDir2);
            FileInfo file1 = new FileInfo(Path.Combine(dir.FullName, "MyFile1.txt"));
            fs.Create(file1);
            FileInfo file2 = new FileInfo(Path.Combine(dir.FullName, "MyFile2.txt"));
            fs.Create(file2);
            IDirectory sut = new Directory(fs, dir);
            IEnumerable<IDirectory> result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.EnumerateDirectories(), out Exception _);

            Test.If.Enumerable.Contains(result, _ => _.Path == subDir1.FullName);
            Test.If.Enumerable.Contains(result, _ => _.Path == subDir2.FullName);
            Test.IfNot.Enumerable.Contains(result, _ => _.Path == file1.FullName);
            Test.IfNot.Enumerable.Contains(result, _ => _.Path == file2.FullName);
            Test.IfNot.Enumerable.Contains(result, _ => _.FileSystem != fs);
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);

        }

        #endregion

        #region EnumerateFiles

        [TestMethod]
        [TestData(nameof(Dir_Data))]
        void EnumerateFilesNotExisting(String subPath) {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, subPath));
            IDirectory sut = new Directory(fs, dir);
            IEnumerable<IFile> result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.EnumerateFiles(), out Exception _);

            Test.If.Enumerable.IsEmpty(result);
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);

        }

        [TestMethod]
        void EnumerateFilesEmpty() {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            fs.Create(dir);
            IDirectory sut = new Directory(fs, dir);
            IEnumerable<IFile> result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.EnumerateFiles(), out Exception _);

            Test.If.Enumerable.IsEmpty(result);
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);

        }

        [TestMethod]
        void EnumerateFilesExisting() {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            fs.Create(dir);
            DirectoryInfo subDir1 = new DirectoryInfo(Path.Combine(dir.FullName, "MySubDir1"));
            fs.Create(subDir1);
            DirectoryInfo subDir2 = new DirectoryInfo(Path.Combine(dir.FullName, "MySubDir2"));
            fs.Create(subDir2);
            FileInfo file1 = new FileInfo(Path.Combine(dir.FullName, "MyFile1.txt"));
            fs.Create(file1);
            FileInfo file2 = new FileInfo(Path.Combine(dir.FullName, "MyFile2.txt"));
            fs.Create(file2);
            IDirectory sut = new Directory(fs, dir);
            IEnumerable<IFile> result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.EnumerateFiles(), out Exception _);

            Test.IfNot.Enumerable.Contains(result, _ => _.Path == subDir1.FullName);
            Test.IfNot.Enumerable.Contains(result, _ => _.Path == subDir2.FullName);
            Test.If.Enumerable.Contains(result, _ => _.Path == file1.FullName);
            Test.If.Enumerable.Contains(result, _ => _.Path == file2.FullName);
            Test.IfNot.Enumerable.Contains(result, _ => _.FileSystem != fs);
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);

        }

        #endregion

        #region EnumerateFileSystemEntities

        [TestMethod]
        [TestData(nameof(Dir_Data))]
        void EnumerateFileSystemEntitiesNotExisting(String subPath) {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, subPath));
            IDirectory sut = new Directory(fs, dir);
            IEnumerable<IFileSystemEntity> result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.EnumerateFileSystemEntities(), out Exception _);

            Test.If.Enumerable.IsEmpty(result);
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);

        }

        [TestMethod]
        void EnumerateFileSystemEntitiesEmpty() {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            fs.Create(dir);
            IDirectory sut = new Directory(fs, dir);
            IEnumerable<IFileSystemEntity> result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.EnumerateFileSystemEntities(), out Exception _);

            Test.If.Enumerable.IsEmpty(result);
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);

        }

        [TestMethod]
        void EnumerateFileSystemEntitiesExisting() {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            fs.Create(dir);
            DirectoryInfo subDir1 = new DirectoryInfo(Path.Combine(dir.FullName, "MySubDir1"));
            fs.Create(subDir1);
            DirectoryInfo subDir2 = new DirectoryInfo(Path.Combine(dir.FullName, "MySubDir2"));
            fs.Create(subDir2);
            FileInfo file1 = new FileInfo(Path.Combine(dir.FullName, "MyFile1.txt"));
            fs.Create(file1);
            FileInfo file2 = new FileInfo(Path.Combine(dir.FullName, "MyFile2.txt"));
            fs.Create(file2);
            IDirectory sut = new Directory(fs, dir);
            IEnumerable<IFileSystemEntity> result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.EnumerateFileSystemEntities(), out Exception _);

            Test.If.Enumerable.Contains(result, _ => _.Path == subDir1.FullName);
            Test.If.Enumerable.Contains(result, _ => _.Path == subDir2.FullName);
            Test.If.Enumerable.Contains(result, _ => _.Path == file1.FullName);
            Test.If.Enumerable.Contains(result, _ => _.Path == file2.FullName);
            Test.IfNot.Enumerable.Contains(result, _ => _.FileSystem != fs);
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);

        }

        #endregion

        #region CopyTo

        [TestMethod]
        void CopyTo_ThrowsArgNullEx() {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            IDirectory sut = new Directory(fs, dir);

            Test.If.Action.ThrowsException(() => sut.CopyTo(null), out ArgumentNullException ex);

            Test.If.Value.IsEqual(ex.ParamName, "target");
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);

        }

        [TestMethod]
        void CopyNotExistingToNotExisting() {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            DirectoryInfo newDir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyNewDir"));
            IDirectory sut = new Directory(fs, dir);
            IDirectory target = new Directory(fs, newDir);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.CopyTo(target), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Value.IsFalse(fs.Exists(dir));
            Test.If.Value.IsFalse(fs.Exists(newDir));
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);

        }

        [TestMethod]
        void CopyExistingToNotExisting() {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            fs.Create(dir);
            DirectoryInfo subDir = new DirectoryInfo(Path.Combine(dir.FullName, "MySubDir"));
            fs.Create(subDir);
            FileInfo file = new FileInfo(Path.Combine(dir.FullName, "MyFile.txt"));
            fs.Create(file);
            DirectoryInfo newDir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyNewDir"));
            DirectoryInfo newSubDir = new DirectoryInfo(Path.Combine(newDir.FullName, "MySubDir"));
            FileInfo newFile = new FileInfo(Path.Combine(newDir.FullName, "MyFile.txt"));
            IDirectory sut = new Directory(fs, dir);
            IDirectory target = new Directory(fs, newDir);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.CopyTo(target), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsTrue(fs.Exists(dir));
            Test.If.Value.IsTrue(fs.Exists(subDir));
            Test.If.Value.IsTrue(fs.Exists(file));
            Test.If.Value.IsTrue(fs.Exists(newDir));
            Test.If.Value.IsTrue(fs.Exists(newSubDir));
            Test.If.Value.IsTrue(fs.Exists(newFile));
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);

        }

        [TestMethod]
        void CopyNotExistingToExisting() {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            DirectoryInfo newDir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyNewDir"));
            fs.Create(newDir);
            IDirectory sut = new Directory(fs, dir);
            IDirectory target = new Directory(fs, newDir);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.CopyTo(target), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Value.IsFalse(fs.Exists(dir));
            Test.If.Value.IsTrue(fs.Exists(newDir));
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);

        }

        [TestMethod]
        void CopyExistingToExisting() {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            fs.Create(dir);
            DirectoryInfo newDir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyNewDir"));
            fs.Create(newDir);
            IDirectory sut = new Directory(fs, dir);
            IDirectory target = new Directory(fs, newDir);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.CopyTo(target), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Value.IsTrue(fs.Exists(dir));
            Test.If.Value.IsTrue(fs.Exists(newDir));
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);

        }

        [TestMethod]
        void CopyExistingToSelf() {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            fs.Create(dir);
            DirectoryInfo newDir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            IDirectory sut = new Directory(fs, dir);
            IDirectory target = new Directory(fs, newDir);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.CopyTo(target), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsTrue(fs.Exists(dir));
            Test.If.Value.IsTrue(fs.Exists(newDir));
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, newDir.FullName);

        }

        [TestMethod]
        void CopyNotExistingToSelf() {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            DirectoryInfo newDir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            IDirectory sut = new Directory(fs, dir);
            IDirectory target = new Directory(fs, newDir);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.CopyTo(target), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Value.IsFalse(fs.Exists(dir));
            Test.If.Value.IsFalse(fs.Exists(newDir));
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);

        }

        [TestMethod]
        void CopyToRemote() {

            IFileSystem fs1 = new FakeFileSystem();
            IFileSystem fs2 = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            fs1.Create(dir);
            DirectoryInfo subDir = new DirectoryInfo(Path.Combine(dir.FullName, "MySubDir"));
            fs1.Create(subDir);
            FileInfo file = new FileInfo(Path.Combine(dir.FullName, "MyFile.txt"));
            fs1.Create(file);
            DirectoryInfo newDir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyNewDir"));
            DirectoryInfo newSubDir = new DirectoryInfo(Path.Combine(newDir.FullName, "MySubDir"));
            FileInfo newFile = new FileInfo(Path.Combine(newDir.FullName, "MyFile.txt"));
            IDirectory sut = new Directory(fs1, dir);
            IDirectory target = new Directory(fs2, newDir);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.CopyTo(target), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsTrue(fs1.Exists(dir));
            Test.If.Value.IsTrue(fs1.Exists(subDir));
            Test.If.Value.IsTrue(fs1.Exists(file));
            Test.If.Value.IsFalse(fs1.Exists(newDir));
            Test.If.Value.IsFalse(fs1.Exists(newSubDir));
            Test.If.Value.IsFalse(fs1.Exists(newFile));
            Test.If.Value.IsFalse(fs2.Exists(dir));
            Test.If.Value.IsFalse(fs2.Exists(subDir));
            Test.If.Value.IsFalse(fs2.Exists(file));
            Test.If.Value.IsTrue(fs2.Exists(newDir));
            Test.If.Value.IsTrue(fs2.Exists(newSubDir));
            Test.If.Value.IsTrue(fs2.Exists(newFile));
            Test.If.Reference.IsEqual(fs1, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);

        }

        #endregion

        #region MoveTo

        [TestMethod]
        void MoveTo_ThrowsArgNullEx() {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            IDirectory sut = new Directory(fs, dir);

            Test.If.Action.ThrowsException(() => sut.MoveTo(null), out ArgumentNullException ex);

            Test.If.Value.IsEqual(ex.ParamName, "target");
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);

        }

        [TestMethod]
        void MoveNotExistingToNotExisting() {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            DirectoryInfo newDir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyNewDir"));
            IDirectory sut = new Directory(fs, dir);
            IDirectory target = new Directory(fs, newDir);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.MoveTo(target), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Value.IsFalse(fs.Exists(dir));
            Test.If.Value.IsFalse(fs.Exists(newDir));
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);

        }

        [TestMethod]
        void MoveExistingToNotExisting() {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            fs.Create(dir);
            DirectoryInfo subDir = new DirectoryInfo(Path.Combine(dir.FullName, "MySubDir"));
            fs.Create(subDir);
            FileInfo file = new FileInfo(Path.Combine(dir.FullName, "MyFile.txt"));
            fs.Create(file);
            DirectoryInfo newDir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyNewDir"));
            DirectoryInfo newSubDir = new DirectoryInfo(Path.Combine(newDir.FullName, "MySubDir"));
            FileInfo newFile = new FileInfo(Path.Combine(newDir.FullName, "MyFile.txt"));
            IDirectory sut = new Directory(fs, dir);
            IDirectory target = new Directory(fs, newDir);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.MoveTo(target), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsFalse(fs.Exists(dir));
            Test.If.Value.IsFalse(fs.Exists(subDir));
            Test.If.Value.IsFalse(fs.Exists(file));
            Test.If.Value.IsTrue(fs.Exists(newDir));
            Test.If.Value.IsTrue(fs.Exists(newSubDir));
            Test.If.Value.IsTrue(fs.Exists(newFile));
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);

        }

        [TestMethod]
        void MoveNotExistingToExisting() {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            DirectoryInfo newDir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyNewDir"));
            fs.Create(newDir);
            IDirectory sut = new Directory(fs, dir);
            IDirectory target = new Directory(fs, newDir);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.MoveTo(target), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Value.IsFalse(fs.Exists(dir));
            Test.If.Value.IsTrue(fs.Exists(newDir));
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);

        }

        [TestMethod]
        void MoveExistingToExisting() {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            fs.Create(dir);
            DirectoryInfo newDir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyNewDir"));
            fs.Create(newDir);
            IDirectory sut = new Directory(fs, dir);
            IDirectory target = new Directory(fs, newDir);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.MoveTo(target), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Value.IsTrue(fs.Exists(dir));
            Test.If.Value.IsTrue(fs.Exists(newDir));
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);

        }

        [TestMethod]
        void MoveExistingToSelf() {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            fs.Create(dir);
            DirectoryInfo newDir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            IDirectory sut = new Directory(fs, dir);
            IDirectory target = new Directory(fs, newDir);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.MoveTo(target), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsTrue(fs.Exists(dir));
            Test.If.Value.IsTrue(fs.Exists(newDir));
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, newDir.FullName);

        }

        [TestMethod]
        void MoveNotExistingToSelf() {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            DirectoryInfo newDir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            IDirectory sut = new Directory(fs, dir);
            IDirectory target = new Directory(fs, newDir);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.MoveTo(target), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Value.IsFalse(fs.Exists(dir));
            Test.If.Value.IsFalse(fs.Exists(newDir));
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);

        }

        [TestMethod]
        void MoveToRemote() {

            IFileSystem fs1 = new FakeFileSystem();
            IFileSystem fs2 = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            fs1.Create(dir);
            DirectoryInfo subDir = new DirectoryInfo(Path.Combine(dir.FullName, "MySubDir"));
            fs1.Create(subDir);
            FileInfo file = new FileInfo(Path.Combine(dir.FullName, "MyFile.txt"));
            fs1.Create(file);
            DirectoryInfo newDir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyNewDir"));
            DirectoryInfo newSubDir = new DirectoryInfo(Path.Combine(newDir.FullName, "MySubDir"));
            FileInfo newFile = new FileInfo(Path.Combine(newDir.FullName, "MyFile.txt"));
            IDirectory sut = new Directory(fs1, dir);
            IDirectory target = new Directory(fs2, newDir);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.MoveTo(target), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsFalse(fs1.Exists(dir));
            Test.If.Value.IsFalse(fs1.Exists(subDir));
            Test.If.Value.IsFalse(fs1.Exists(file));
            Test.If.Value.IsFalse(fs1.Exists(newDir));
            Test.If.Value.IsFalse(fs1.Exists(newSubDir));
            Test.If.Value.IsFalse(fs1.Exists(newFile));
            Test.If.Value.IsFalse(fs2.Exists(dir));
            Test.If.Value.IsFalse(fs2.Exists(subDir));
            Test.If.Value.IsFalse(fs2.Exists(file));
            Test.If.Value.IsTrue(fs2.Exists(newDir));
            Test.If.Value.IsTrue(fs2.Exists(newSubDir));
            Test.If.Value.IsTrue(fs2.Exists(newFile));
            Test.If.Reference.IsEqual(fs1, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);

        }

        #endregion

        #region CreateDirectory

        [TestMethod]
        void CreateDirectory_ThrowsArgNullEx() {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            IDirectory sut = new Directory(fs, dir);

            Test.If.Action.ThrowsException(() => sut.CreateDirectory(null), out ArgumentNullException ex);

            Test.If.Value.IsEqual(ex.ParamName, "name");
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);
        }

        [TestMethod]
        [TestParameters("")]
        [TestParameters(" ")]
        void CreateDirectory_ThrowsArgEx(String name) {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            IDirectory sut = new Directory(fs, dir);

            Test.If.Action.ThrowsException(() => sut.CreateDirectory(name), out ArgumentException ex);

            Test.If.Value.IsEqual(ex.ParamName, "name");
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);
        }

        [TestMethod]
        void CreateNotExistingDirectory() {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            DirectoryInfo child = new DirectoryInfo(Path.Combine(dir.FullName, "MySubDir"));
            IDirectory sut = new Directory(fs, dir);
            IDirectory result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.CreateDirectory(child.Name), out Exception _);

            Test.IfNot.Object.IsNull(result);
            Test.If.Value.IsTrue(fs.Exists(child));
            Test.If.Reference.IsEqual(fs, result.FileSystem);
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);

        }

        [TestMethod]
        void CreateExistingDirectory() {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            DirectoryInfo child = new DirectoryInfo(Path.Combine(dir.FullName, "MySubDir"));
            fs.Create(child);
            IDirectory sut = new Directory(fs, dir);
            IDirectory result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.CreateDirectory(child.Name), out Exception _);

            Test.IfNot.Object.IsNull(result);
            Test.If.Value.IsTrue(fs.Exists(child));
            Test.If.Reference.IsEqual(fs, result.FileSystem);
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);

        }

        #endregion

        #region CreateFile

        [TestMethod]
        void CreateFile_ThrowsArgNullEx() {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            IDirectory sut = new Directory(fs, dir);

            Test.If.Action.ThrowsException(() => sut.CreateFile(null), out ArgumentNullException ex);

            Test.If.Value.IsEqual(ex.ParamName, "name");
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);

        }

        [TestMethod]
        [TestParameters("")]
        [TestParameters(" ")]
        void CreateFile_ThrowsArgEx(String name) {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            IDirectory sut = new Directory(fs, dir);

            Test.If.Action.ThrowsException(() => sut.CreateFile(name), out ArgumentException ex);

            Test.If.Value.IsEqual(ex.ParamName, "name");
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);

        }

        [TestMethod]
        void CreateNotExistingFile() {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            FileInfo child = new FileInfo(Path.Combine(dir.FullName, "MyFile.txt"));
            IDirectory sut = new Directory(fs, dir);
            IFile result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.CreateFile(child.Name), out Exception _);

            Test.IfNot.Object.IsNull(result);
            Test.If.Value.IsTrue(fs.Exists(child));
            Test.If.Reference.IsEqual(fs, result.FileSystem);
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);

        }

        [TestMethod]
        void CreateExistingFile() {

            IFileSystem fs = new FakeFileSystem();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_tempDir.FullName, "MyDir"));
            FileInfo child = new FileInfo(Path.Combine(dir.FullName, "MyFile.txt"));
            fs.Create(child);
            IDirectory sut = new Directory(fs, dir);
            IFile result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.CreateFile(child.Name), out Exception _);

            Test.IfNot.Object.IsNull(result);
            Test.If.Value.IsTrue(fs.Exists(child));
            Test.If.Reference.IsEqual(fs, result.FileSystem);
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, dir.FullName);

        }

        #endregion

        #region data, setup & teardown

        internal DirectoryInfo _tempDir = new DirectoryInfo(Path.Combine(Path.GetTempPath(), $"UTESTS_{Guid.NewGuid()}"));

        IEnumerable<Object[]> Dir_Data() {
            yield return new Object[] { "MyDir" };
            yield return new Object[] { @"NotExisting\MyDir" };
        }

        #endregion

    }
}
