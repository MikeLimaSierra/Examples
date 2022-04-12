using System;
using System.Collections.Generic;
using System.IO;

namespace TestDrivenDiscipline.Contracts {

    /// <summary>
    /// Defines a file system.
    /// </summary>
    public interface IFileSystem {

        /// <summary>
        /// Creates a new file at the given <paramref name="file"/> path.
        /// </summary>
        /// <param name="file">The file to create.</param>
        /// <returns>True if the file was created or if it already existed.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="file"/> is null.</exception>
        Boolean Create(FileInfo file);

        /// <summary>
        /// Creates a new directory at the given <paramref name="directory"/> path.
        /// </summary>
        /// <param name="directory">The directory to create.</param>
        /// <returns>True if the directory was created or if it already existed.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="directory"/> is null.</exception>
        Boolean Create(DirectoryInfo directory);

        /// <summary>
        /// Deletes an existing file at the given <paramref name="file"/> path.
        /// </summary>
        /// <param name="file">The file to delete.</param>
        /// <returns>True if the file was deleted or if it didn't exist.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="file"/> is null.</exception>
        Boolean Delete(FileInfo file);

        /// <summary>
        /// Deletes an existing directory at the given <paramref name="directory"/> path.
        /// </summary>
        /// <param name="directory">The directory to delete.</param>
        /// <returns>True if the directory was deleted or if it didn't exist.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="directory"/> is null.</exception>
        Boolean Delete(DirectoryInfo directory);

        /// <summary>
        /// Checks if a file exists at the given <paramref name="file"/> path.
        /// </summary>
        /// <param name="file">The file to check.</param>
        /// <returns>True if the file exists.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="file"/> is null.</exception>
        Boolean Exists(FileInfo file);

        /// <summary>
        /// Checks if a directory exists at the given <paramref name="directory"/> path.
        /// </summary>
        /// <param name="directory">The directory to check.</param>
        /// <returns>True if the directory exists.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="directory"/> is null.</exception>
        Boolean Exists(DirectoryInfo directory);

        /// <summary>
        /// Gets all existing sub directories in <paramref name="directory"/>.
        /// </summary>
        /// <param name="directory">The directory where to look.</param>
        /// <returns>A collection of directories.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="directory"/> is null.</exception>
        IEnumerable<DirectoryInfo> EnumerateDirectories(DirectoryInfo directory);

        /// <summary>
        /// Gets all existing files in <paramref name="directory"/>.
        /// </summary>
        /// <param name="directory">The directory where to look.</param>
        /// <returns>A collection of files.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="directory"/> is null.</exception>
        IEnumerable<FileInfo> EnumerateFiles(DirectoryInfo directory);

    }
}
