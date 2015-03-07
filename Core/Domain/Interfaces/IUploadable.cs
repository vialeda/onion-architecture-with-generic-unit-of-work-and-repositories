using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viainternet.OnionArchitecture.Core.Interfaces
{
    public interface IUploadable
    {
        /// <summary>
        /// Represent the name of the file.
        /// </summary>
        string FileName { get; set; }
        /// <summary>
        /// Represent the friendly name of the file.
        /// </summary>
        string DisplayFileName { get; set; }
        /// <summary>
        /// Represent the content type of the file.
        /// </summary>
        string ContentType { get; set; }
        /// <summary>
        /// Represent the file extension.
        /// </summary>
        string FileExtension { get; set; }
        /// <summary>
        /// Represent the file under binary data.
        /// </summary>
        byte[] File { get; set; }
        /// <summary>
        /// Reprensent the description of the file.
        /// </summary>
        string FileDescription { get; set; }
        /// <summary>
        /// Represent the length of the file.
        /// </summary>
        string ContentLength { get; set; }
    }
    /// <summary>
    /// Used for ViewModel with file upload control.
    /// </summary>
    public interface IFileUploaded : IUploadable
    {
        // TODO: Uncomment when finish structure the core
        //HttpPostedFileBase FileUpload { get; set; }
        bool IsValid { get; set; }
    }
}
