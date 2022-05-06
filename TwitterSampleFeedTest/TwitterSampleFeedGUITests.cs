using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jasonphos.TwitterSampleFeedGUI;
using System.IO;
using Jasonphos.SharedUtil.Util;

namespace Jasonphos.TwitterSampleFeedTest {
    [TestClass]
    public class TwitterSampleFeedGUITests {
        [TestMethod]
        public void TestBearerTokenSave(){
            string testBearerToken = "BlahBlahTestValueBlahBlah!!!!!!!!!!!!!!!!!";
            const string SECRETS_FILE_NAME = "Secrets.config";
            const string TEMP_FILE_NAME = "_" + SECRETS_FILE_NAME;
            bool isFileExists = false;

            if(File.Exists(TEMP_FILE_NAME))
                File.Delete(TEMP_FILE_NAME);
            if(File.Exists("Secrets.config")) {
                isFileExists = true;
                File.Move(SECRETS_FILE_NAME,TEMP_FILE_NAME);
            }

            Main frmMain = new Main();
            frmMain.SetBearerToken(testBearerToken);
            frmMain.SaveBearerToken();

            bool areFilesEqual = FileUtil.AreFileContentsEqual("Secrets.config",@"TestCaseData\SampleSecretsConfig.txt");

            //Cleanup this file as we don't want it to stick around
            File.Delete(SECRETS_FILE_NAME);
            if(isFileExists)
                File.Move(TEMP_FILE_NAME,SECRETS_FILE_NAME);

            Assert.IsTrue(areFilesEqual);
            
        }
    }
}