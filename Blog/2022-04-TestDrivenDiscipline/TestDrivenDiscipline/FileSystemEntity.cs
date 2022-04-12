using System;

using TestDrivenDiscipline.Contracts;

namespace TestDrivenDiscipline {
    public abstract class FileSystemEntity : IFileSystemEntity {

        public IFileSystem FileSystem { get; }

        public abstract String Name { get; }

        public abstract String Path { get; }

        public abstract Boolean Exists { get; }

        public FileSystemEntity(IFileSystem fileSystem) {
            FileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
        }

        public abstract Boolean Create();

        public abstract Boolean Delete();

    }
}
