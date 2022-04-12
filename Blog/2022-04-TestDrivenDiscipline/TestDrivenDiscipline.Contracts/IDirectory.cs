using System;
using System.Collections.Generic;

namespace TestDrivenDiscipline.Contracts {

    /// <summary>
    /// Defines a node type file system entity.
    /// </summary>
    public interface IDirectory : IFileSystemEntity {

        /// <summary>
        /// Gets the parent directory.
        /// </summary>
        IDirectory Parent { get; }

        /// <summary>
        /// Gets the root directory.
        /// </summary>
        IDirectory Root { get; }

        /// <summary>
        /// Gets all contained sub directories.
        /// </summary>
        /// <returns>A collection of <see cref="IDirectory"/>.</returns>
        IEnumerable<IDirectory> EnumerateDirectories();

        /// <summary>
        /// Gets all contained files.
        /// </summary>
        /// <returns>A collection of <see cref="IFile"/>.</returns>
        IEnumerable<IFile> EnumerateFiles();

        /// <summary>
        /// Gets all contained entites.
        /// </summary>
        /// <returns>A collection of <see cref="IFileSystemEntity"/>.</returns>
        IEnumerable<IFileSystemEntity> EnumerateFileSystemEntities();

        /// <summary>
        /// Copies the directory and all contained entities to the new location.
        /// </summary>
        /// <param name="target">The new location.</param>
        /// <returns>True if the directory was copied or if the new location matched the old one. False if the directory didn't exist or if the new name is already taken.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="target"/> is null.</exception>
        Boolean CopyTo(IDirectory target);

        /// <summary>
        /// Moves the directory and all contained entities to the new location.
        /// </summary>
        /// <param name="target">The new location.</param>
        /// <returns>True if the directory was moved or if the new location matched the old one. False if the directory didn't exist or if the new name is already taken.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="target"/> is null.</exception>
        Boolean MoveTo(IDirectory target);

        /// <summary>
        /// Creates a new child directory.
        /// </summary>
        /// <param name="name">The name of the new directory.</param>
        /// <returns>The new child directory.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="name"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="name"/> is empty or white-space.</exception>
        IDirectory CreateDirectory(String name);

        /// <summary>
        /// Creates a new file in the directory.
        /// </summary>
        /// <param name="name">The name of the file.</param>
        /// <returns>The new file.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="name"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="name"/> is empty or white-space.</exception>
        IFile CreateFile(String name);

    }
}
