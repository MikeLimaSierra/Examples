using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using TestDrivenDiscipline.Contracts;

namespace TestDrivenDiscipline {
    public class RealFileSystem : IFileSystem {

        public Boolean Create(FileInfo file) {
            if(file == null) { throw new ArgumentNullException(nameof(file)); }

            Create(file.Directory);
            file.Create().Close();

            return Exists(file);
        }

        public Boolean Create(DirectoryInfo directory) {
            if(directory == null) { throw new ArgumentNullException(nameof(directory)); }

            directory.Create();

            return Exists(directory);
        }

        public Boolean Delete(FileInfo file) {
            if(file == null) { throw new ArgumentNullException(nameof(file)); }

            if(Exists(file)) {
                file.Delete();
            }

            return !Exists(file);
        }

        public Boolean Delete(DirectoryInfo directory) {
            if(directory == null) { throw new ArgumentNullException(nameof(directory)); }

            if(Exists(directory)) {
                directory.Delete(true);
            }

            return !Exists(directory);
        }

        public Boolean Exists(FileInfo file) {
            if(file == null) { throw new ArgumentNullException(nameof(file)); }

            file.Refresh();

            return file.Exists;
        }

        public Boolean Exists(DirectoryInfo directory) {
            if(directory == null) { throw new ArgumentNullException(nameof(directory)); }

            directory.Refresh();

            return directory.Exists;
        }

        public IEnumerable<DirectoryInfo> EnumerateDirectories(DirectoryInfo directory) {
            if(directory == null) { throw new ArgumentNullException(nameof(directory)); }

            directory.Refresh();

            return directory.Exists ? directory.EnumerateDirectories() : Enumerable.Empty<DirectoryInfo>();
        }

        public IEnumerable<FileInfo> EnumerateFiles(DirectoryInfo directory) {
            if(directory == null) { throw new ArgumentNullException(nameof(directory)); }

            directory.Refresh();

            return directory.Exists ? directory.EnumerateFiles() : Enumerable.Empty<FileInfo>();
        }
    }
}
