using System;

using TestDrivenDiscipline;
using TestDrivenDiscipline.Contracts;

namespace TestDrivenDiscipline_uTests {
    class DummyFileSystemEntity : FileSystemEntity {
        public override String Name { get; }
        public override String Path { get; }
        public override Boolean Exists { get; }

        public DummyFileSystemEntity(IFileSystem fileSystem) : base(fileSystem) { }

        public override Boolean Create() => throw new NotImplementedException();
        public override Boolean Delete() => throw new NotImplementedException();
    }
}
