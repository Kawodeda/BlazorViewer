
namespace BlazorViewer.Server.Services
{
    public class DesignFileStorageService : IProtoStorageService
    {
        private readonly IConfiguration _configuration;
        private readonly INameGeneratorService _nameGeneratorService;

        public string StoragePath
        {
            get
            {
                return _configuration["FileStoragePath"];
            }
        }

        public string FileExtension
        {
            get
            {
                return _configuration["StorageFileExtension"];
            }
        }

        public DesignFileStorageService(
            IConfiguration configuration,
            INameGeneratorService nameGeneratorService)
        {
            _configuration = configuration;
            _nameGeneratorService = nameGeneratorService;
        }

        public void Create(Stream data)
        {
            string filename = _nameGeneratorService.Generate("design");
            CreateFile(filename, data);
        }

        public Stream Retrieve(string name)
        {
            string path = GetPath(name);

            return RetrieveFromPath(path);
        }

        public IEnumerable<string> Retrieve()
        {
            return GetFileNames(StoragePath, FileExtension);
        }

        public void Update(string name, Stream data)
        {
            CreateFile(name, data);
        }

        public void Delete(string name)
        {
            string path = GetPath(name);
            File.Delete(path);
        }

        private Stream RetrieveFromPath(string path)
        {
            MemoryStream result = new MemoryStream();
            using (FileStream input = File.OpenRead(path))
            {
                input.CopyTo(result);
            }
            result.Position = 0;

            return result;
        }

        private void CreateFile(string name, Stream data)
        {
            string path = GetPath(name);

            Directory.CreateDirectory(StoragePath);
            using (FileStream output = File.Create(path))
            {
                data.CopyTo(output);
            }
        }

        private string GetPath(string filename)
        {
            return $"{StoragePath}{filename}{FileExtension}";
        }

        private IEnumerable<string> GetFileNames(
            string directoryPath, 
            string fileExtension)
        {
            return Directory
                .EnumerateFiles(directoryPath, $"*{fileExtension}")
                .Select(
                    x => x
                    .Replace(FileExtension, "")
                    .Split('/')
                    .Last());
        }
    }
}
