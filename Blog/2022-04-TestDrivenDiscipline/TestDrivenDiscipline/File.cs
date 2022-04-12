using System;
using System.IO;

using TestDrivenDiscipline.Contracts;

namespace TestDrivenDiscipline {
    public class File : FileSystemEntity, IFile {

        private readonly FileInfo _file;

        public override String Name => _file.Name;

        public override String Path => _file.FullName;

        public override Boolean Exists => FileSystem.Exists(_file);

        public IDirectory Directory => new Directory(FileSystem, _file.Directory);

        public File(FileInfo file) : this(new RealFileSystem(), file) { }

        public File(IFileSystem fileSystem, FileInfo file) : base(fileSystem) {
            _file = file ?? throw new ArgumentNullException(nameof(file));
        }

        public override Boolean Create() => FileSystem.Create(_file);

        public override Boolean Delete() => FileSystem.Delete(_file);

        public Stream OpenRead() => throw new NotImplementedException();

        public Stream OpenWrite() => throw new NotImplementedException();

        public Boolean CopyTo(IFile target) {
            if(target == null) { throw new ArgumentNullException(nameof(target)); }

            if(!Exists) {
                return false;
            }

            if(_file.FullName == target.Path) {
                return true;
            }

            if(!target.Exists) {
                target.Create();

                return Exists && target.Exists;
            }

            return false;
        }

        public Boolean MoveTo(IFile target) {
            if(target == null) { throw new ArgumentNullException(nameof(target)); }

            if(!Exists) {
                return false;
            }

            if(_file.FullName == target.Path) {
                return true;
            }

            if(!target.Exists) {
                target.Create();
                Delete();

                return !Exists && target.Exists;
            }

            return false;
        }

    }
}
