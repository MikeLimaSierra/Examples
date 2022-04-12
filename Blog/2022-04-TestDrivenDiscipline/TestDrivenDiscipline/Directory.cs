using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using TestDrivenDiscipline.Contracts;

namespace TestDrivenDiscipline {
    public class Directory : FileSystemEntity, IDirectory {

        private readonly DirectoryInfo _directory;

        public override String Name => _directory.Name;

        public override String Path => _directory.FullName;

        public override Boolean Exists => FileSystem.Exists(_directory);

        public IDirectory Parent => new Directory(FileSystem, _directory.Parent);

        public IDirectory Root => new Directory(FileSystem, _directory.Root);

        public Directory(DirectoryInfo directory) : this(new RealFileSystem(), directory) { }

        public Directory(IFileSystem fileSystem, DirectoryInfo directory) : base(fileSystem) {
            _directory = directory ?? throw new ArgumentNullException(nameof(directory));
        }

        public override Boolean Create() => FileSystem.Create(_directory);

        public override Boolean Delete() => FileSystem.Delete(_directory);

        public IEnumerable<IDirectory> EnumerateDirectories() => FileSystem.EnumerateDirectories(_directory).Select(_ => new Directory(FileSystem, _));

        public IEnumerable<IFile> EnumerateFiles() => FileSystem.EnumerateFiles(_directory).Select(_ => new File(FileSystem, _));

        public IEnumerable<IFileSystemEntity> EnumerateFileSystemEntities() => EnumerateDirectories().Concat<IFileSystemEntity>(EnumerateFiles());

        public Boolean CopyTo(IDirectory target) {
            if(target == null) { throw new ArgumentNullException(nameof(target)); }

            if(!Exists) {
                return false;
            }

            if(_directory.FullName == target.Path) {
                return true;
            }

            if(!target.Exists) {
                target.Create();

                foreach(IDirectory dir in EnumerateDirectories().ToList()) {
                    dir.CopyTo(new Directory(target.FileSystem, new DirectoryInfo(System.IO.Path.Combine(target.Path, dir.Name))));
                }

                foreach(IFile file in EnumerateFiles().ToList()) {
                    file.CopyTo(new File(target.FileSystem, new FileInfo(System.IO.Path.Combine(target.Path, file.Name))));
                }

                return Exists && target.Exists;
            }

            return false;
        }

        public Boolean MoveTo(IDirectory target) {
            if(target == null) { throw new ArgumentNullException(nameof(target)); }

            if(!Exists) {
                return false;
            }

            if(_directory.FullName == target.Path) {
                return true;
            }

            if(!target.Exists) {
                target.Create();

                foreach(IDirectory dir in EnumerateDirectories().ToList()) {
                    dir.MoveTo(new Directory(target.FileSystem, new DirectoryInfo(System.IO.Path.Combine(target.Path, dir.Name))));
                }

                foreach(IFile file in EnumerateFiles().ToList()) {
                    file.MoveTo(new File(target.FileSystem, new FileInfo(System.IO.Path.Combine(target.Path, file.Name))));
                }

                Delete();

                return !Exists && target.Exists;
            }

            return false;
        }

        public IDirectory CreateDirectory(String name) {
            if(name == null) { throw new ArgumentNullException(nameof(name)); }
            if(String.IsNullOrWhiteSpace(name)) { throw new ArgumentException(null, nameof(name)); }

            IDirectory child = new Directory(FileSystem, new DirectoryInfo(System.IO.Path.Combine(Path, name)));

            if(!child.Exists) {
                child.Create();
            }

            return child;
        }

        public IFile CreateFile(String name) {
            if(name == null) { throw new ArgumentNullException(nameof(name)); }
            if(String.IsNullOrWhiteSpace(name)) { throw new ArgumentException(null, nameof(name)); }

            IFile child = new File(FileSystem, new FileInfo(System.IO.Path.Combine(Path, name)));

            if(!child.Exists) {
                child.Create();
            }

            return child;
        }
    }
}
