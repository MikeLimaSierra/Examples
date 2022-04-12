using System;
using System.IO;

using Nuclear.TestSite;

using TestDrivenDiscipline.Contracts;

using FileSystem = TestDrivenDiscipline.RealFileSystem;

namespace TestDrivenDiscipline_uTests {
    class RealFileSystem_uTests {

        #region CreateFile

        [TestMethod]
        void CreateFile_Throws() {

            IFileSystem sut = new FileSystem();

            Test.If.Action.ThrowsException(() => sut.Create((FileInfo) null), out ArgumentNullException ex);

            Test.If.Value.IsEqual(ex.ParamName, "file");

        }

        #endregion

        #region CreateDir

        [TestMethod]
        void CreateDir_Throws() {

            IFileSystem sut = new FileSystem();

            Test.If.Action.ThrowsException(() => sut.Create((DirectoryInfo) null), out ArgumentNullException ex);

            Test.If.Value.IsEqual(ex.ParamName, "directory");

        }

        #endregion

        #region DeleteFile

        [TestMethod]
        void DeleteFile_Throws() {

            IFileSystem sut = new FileSystem();

            Test.If.Action.ThrowsException(() => sut.Delete((FileInfo) null), out ArgumentNullException ex);

            Test.If.Value.IsEqual(ex.ParamName, "file");

        }

        #endregion

        #region DeleteDir

        [TestMethod]
        void DeleteDir_Throws() {

            IFileSystem sut = new FileSystem();

            Test.If.Action.ThrowsException(() => sut.Delete((DirectoryInfo) null), out ArgumentNullException ex);

            Test.If.Value.IsEqual(ex.ParamName, "directory");

        }

        #endregion

        #region ExistsFile

        [TestMethod]
        void ExistsFile_Throws() {

            IFileSystem sut = new FileSystem();

            Test.If.Action.ThrowsException(() => sut.Exists((FileInfo) null), out ArgumentNullException ex);

            Test.If.Value.IsEqual(ex.ParamName, "file");

        }

        #endregion

        #region ExistsDir

        [TestMethod]
        void ExistsDir_Throws() {

            IFileSystem sut = new FileSystem();

            Test.If.Action.ThrowsException(() => sut.Exists((DirectoryInfo) null), out ArgumentNullException ex);

            Test.If.Value.IsEqual(ex.ParamName, "directory");

        }

        #endregion

        #region EnumerateDirectories

        [TestMethod]
        void EnumerateDirectories_Throws() {

            IFileSystem sut = new FileSystem();

            Test.If.Action.ThrowsException(() => sut.EnumerateDirectories(null), out ArgumentNullException ex);

            Test.If.Value.IsEqual(ex.ParamName, "directory");

        }

        #endregion

        #region EnumerateFiles

        [TestMethod]
        void EnumerateFiles_Throws() {

            IFileSystem sut = new FileSystem();

            Test.If.Action.ThrowsException(() => sut.EnumerateFiles(null), out ArgumentNullException ex);

            Test.If.Value.IsEqual(ex.ParamName, "directory");

        }

        #endregion

    }
}
