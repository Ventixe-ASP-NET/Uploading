# Uploading

1. In Models/class "AddUserViewModel" insert (or adjust integration)

"public IFormFile? ImageFile {get; set;}"

2. In Controllers/class "UserController" insert (or adjust integration)

"private readonly IFileHandler _fileHandler;" (line 13)
"var image FileUri = await _filheHandler.UploadFileAsync(model.ImageFile!);" (line 27)
"ImageFileName = imageFileUri," (line 34)

3. UserEntity must contain

"public string? ImageFileName {get; set;)"


Lines and Ref.: https://www.youtube.com/watch?v=1FbwQD3jKO0
