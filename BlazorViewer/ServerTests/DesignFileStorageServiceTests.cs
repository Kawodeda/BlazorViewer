using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BlazorViewer.Server.Services;
using BlazorViewer.Server.Dtos;

namespace ServerTests
{
    public class DesignFileStorageServiceTests
    {
        [Test]
        public void For_UploadDesign_Expect_FileContainingContentIsCreated()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void For_UploadDesign_Expect_ResultIsMetadataOfCreatedDesign()
        {

        }

        [Test]
        public void For_GetDesignInfo_Expect_ResultIsMetadataOfDesignWithGivenName()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void When_UseGetDesignInfoWithNonExistingName_Expect_FileNotFoundExceptionIsThrown()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void For_GetDesignContent_Expect_ResultIsContentOfDesignWithGivenName()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void When_UseGetDesignContentWithNonExistingName_Expect_FileNotFoundExceptionIsThrown()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void For_ListDesigns_Expect_ResultIsMetadataOfAllDesigns()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void For_UpdateDesign_Expect_DesignWithGivenNameIsOverwrittenWithContent()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void For_UpdateDesign_Expect_ResultIsMetadataOfUpdatedDesign()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void When_UseUpdateDesignWithNonExistingName_Expect_NewFileContainingContentIsCreated()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void For_DeleteDesign_Expect_FileWithGivenNameIsDeleted()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void When_UseDeleteDesignWithNonExistingName_Expect_FileNotFoundExceptionIsThrown()
        {
            throw new NotImplementedException();
        }
    }
}
