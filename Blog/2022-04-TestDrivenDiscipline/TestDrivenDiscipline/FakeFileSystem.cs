using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using TestDrivenDiscipline.Contracts;

namespace TestDrivenDiscipline {
    public class FakeFileSystem : IFileSystem {

        private readonly Dictionary<String, Stream> _fileCache = new Dictionary<String, Stream>();

        private readonly List<String> _dirCache = new List<String>();

        public Boolean Create(FileInfo file) {
            if(file == null) { throw new ArgumentNullException(nameof(file)); }

            if(!Exists(file)) {
                _fileCache.Add(file.FullName, null);
                Create(file.Directory);
            }

            return Exists(file);
        }

        public Boolean Create(DirectoryInfo directory) {
            if(directory == null) { throw new ArgumentNullException(nameof(directory)); }

            if(!Exists(directory)) {
                _dirCache.Add(directory.FullName);

                if(directory.Parent != null) {
                    Create(directory.Parent);
                }
            }

            return Exists(directory);
        }

        public Boolean Delete(FileInfo file) {
            if(file == null) { throw new ArgumentNullException(nameof(file)); }

            if(Exists(file)) {
                _fileCache.Remove(file.FullName);
            }

            return !Exists(file);
        }

        public Boolean Delete(DirectoryInfo directory) {
            if(directory == null) { throw new ArgumentNullException(nameof(directory)); }

            if(Exists(directory)) {
                _dirCache.Remove(directory.FullName);

                _dirCache.RemoveAll(_ => _.StartsWith(directory.FullName));

                foreach(KeyValuePair<String, Stream> kvp in _fileCache.Where(_ => _.Key.StartsWith(directory.FullName)).ToList()) {
                    _fileCache.Remove(kvp.Key);
                }
            }

            return !Exists(directory);
        }

        public Boolean Exists(FileInfo file) {
            if(file == null) { throw new ArgumentNullException(nameof(file)); }

            return _fileCache.Keys.Any(_ => _ == file.FullName);
        }

        public Boolean Exists(DirectoryInfo directory) {
            if(directory == null) { throw new ArgumentNullException(nameof(directory)); }

            return _dirCache.Any(_ => _ == directory.FullName);
        }

        public IEnumerable<DirectoryInfo> EnumerateDirectories(DirectoryInfo directory) {
            if(directory == null) { throw new ArgumentNullException(nameof(directory)); }

            return Exists(directory) ? _dirCache.Where(_ => _.StartsWith(directory.FullName) && _ != directory.FullName).Select(_ => new DirectoryInfo(_)) : Enumerable.Empty<DirectoryInfo>();
        }

        public IEnumerable<FileInfo> EnumerateFiles(DirectoryInfo directory) {
            if(directory == null) { throw new ArgumentNullException(nameof(directory)); }

            return Exists(directory) ? _fileCache.Where(_ => _.Key.StartsWith(directory.FullName)).Select(_ => new FileInfo(_.Key)) : Enumerable.Empty<FileInfo>();
        }
    }
}
