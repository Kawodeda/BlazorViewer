
using BlazorViewer.Server.Dtos;
using BlazorViewer.Server.Options;
using Microsoft.Extensions.Options;

namespace BlazorViewer.Server.Services
{
    public class DesignFileStorageService : IDesignStorageService
    {
        private readonly FileStorageOptions _options;
        private readonly INameGeneratorService _nameGeneratorService;

        public DesignFileStorageService(
            IOptions<FileStorageOptions> options,
            INameGeneratorService nameGeneratorService)
        {
            _options = options.Value;
            _nameGeneratorService = nameGeneratorService;
        }

        public DesignDto UploadDesign(Stream content)
        {
            string filename = _nameGeneratorService.Generate("design");

            CreateFile(filename, content);

            return new DesignDto()
            {
                Name = filename
            };
        }

        public DesignDto GetDesignInfo(string name)
        {
            string path = GetPath(name);
            var result = GetFileInfo(path);

            return result;
        }

        public Stream GetDesignContent(string name)
        {
            string path = GetPath(name);

            return GetFromPath(path);
        }

        public IEnumerable<DesignDto> ListDesigns()
        {
            return GetFileInfos();
        }

        public DesignDto UpdateDesign(string name, Stream content)
        {
            CreateFile(name, content);

            return new DesignDto()
            {
                Name = name
            };
        }

        public void DeleteDesign(string name)
        {
            string path = GetPath(name);

            if(File.Exists(path) == false)
            {
                throw new FileNotFoundException();
            }

            File.Delete(path);
        }

        private Stream GetFromPath(string path)
        {
            MemoryStream result = new MemoryStream();
            using (FileStream input = File.OpenRead(path))
            {
                input.CopyTo(result);
            }
            result.Position = 0;

            return result;
        }

        private void CreateFile(string name, Stream content)
        {
            string path = GetPath(name);

            Directory.CreateDirectory(_options.Path);
            using (FileStream output = File.Create(path))
            {
                content.CopyTo(output);
            }
        }

        private string GetPath(string filename)
        {           
            return Path.Combine(_options.Path, $"{filename}{_options.FileExtension}");
        }

        private IEnumerable<DesignDto> GetFileInfos()
        {
            return Directory
                .EnumerateFiles(_options.Path, $"*{_options.FileExtension}")
                .Select(x => GetFileInfo(x));
        }

        private DesignDto GetFileInfo(string path)
        {
            if (File.Exists(path) == false)
            {
                throw new FileNotFoundException();
            }

            string name = Path.GetFileNameWithoutExtension(path);

            return new DesignDto()
            {
                Name = name
            };
        }
    }
}
