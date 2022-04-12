using System;

namespace TestDrivenDiscipline.Contracts {

    /// <summary>
    /// Defines an entity in a file system.
    /// </summary>
    public interface IFileSystemEntity {

        /// <summary>
        /// Gets the file system that the entity belongs to.
        /// </summary>
        IFileSystem FileSystem { get; }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        String Name { get; }

        /// <summary>
        /// Gets the full path of the entity within the <see cref="FileSystem"/>.
        /// </summary>
        String Path { get; }

        /// <summary>
        /// Gets if the entity exists within the <see cref="FileSystem"/>.
        /// </summary>
        Boolean Exists { get; }

        /// <summary>
        /// Creates the entity if it does not yet exist.
        /// </summary>
        /// <returns>True if the entity was created or if it already existed.</returns>
        Boolean Create();

        /// <summary>
        /// Deletes the entity if it does exist.
        /// </summary>
        /// <returns>True if the entity was deleted or if it didn't exist.</returns>
        Boolean Delete();

    }
}
