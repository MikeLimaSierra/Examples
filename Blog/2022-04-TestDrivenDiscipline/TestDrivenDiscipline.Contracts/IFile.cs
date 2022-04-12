using System;
using System.IO;

namespace TestDrivenDiscipline.Contracts {

    /// <summary>
    /// Defines a leaf type file system entity.
    /// </summary>
    public interface IFile : IFileSystemEntity {

        /// <summary>
        /// Gets the directory of the file.
        /// </summary>
        IDirectory Directory { get; }

        /// <summary>
        /// Gets a read-only stream of the file.
        /// </summary>
        /// <returns>A read-only stream.</returns>
        Stream OpenRead();

        /// <summary>
        /// Gets a read-write stream of the file.
        /// </summary>
        /// <returns>A read-write stream.</returns>
        Stream OpenWrite();

        /// <summary>
        /// Copies the file to the new location.
        /// </summary>
        /// <param name="target">The new location.</param>
        /// <returns>True if the file was copied or if the new location matched the old one. False if the file didn't exist or if the new name is already taken.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="target"/> is null.</exception>
        Boolean CopyTo(IFile target);

        /// <summary>
        /// Moves the file to the new location.
        /// </summary>
        /// <param name="target">The new location.</param>
        /// <returns>True if the file was moved or if the new location matched the old one. False if the file didn't exist or if the new name is already taken.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="target"/> is null.</exception>
        Boolean MoveTo(IFile target);

    }
}
