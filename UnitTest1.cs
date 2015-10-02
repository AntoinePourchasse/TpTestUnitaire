using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileSystem;

namespace UnitTestFileSystem
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCdFile()
        {
            Directory dossier = new Directory("dossier", null);
            dossier.chmod("7");
            dossier.createNewFile("file");
            Assert.AreEqual(dossier.cd("file"), dossier.files[0]);
        }

        [TestMethod]
        public void TestCdDirectory()
        {
            Directory dossier = new Directory("dossier", null);
            dossier.chmod("7");
            dossier.mkdir("directory");
            Assert.AreEqual(dossier.cd("directory"), dossier.files[0]);
        }

        [TestMethod]
        public void TestChmod1()
        {
            Directory dossier = new Directory("dossier", null);
            dossier.chmod("1");
            Assert.AreEqual(dossier.Permission, 1);
        }

        [TestMethod]
        public void TestChmod7()
        {
            Directory dossier = new Directory("dossier", null);
            dossier.chmod("7");
            Assert.AreEqual(dossier.Permission, 7);
        }

        [TestMethod]
        public void TestChmod2()
        {
            Directory dossier = new Directory("dossier", null);
            dossier.chmod("2");
            Assert.AreEqual(dossier.Permission, 2);
        }

        [TestMethod]
        public void TestChmod4()
        {
            Directory dossier = new Directory("dossier", null);
            dossier.chmod("4");
            Assert.AreEqual(dossier.Permission, 4);
        }

        [TestMethod]
        public void TestCreateFiledansFile()
        {
            File file = new File("file", null);
            Assert.IsFalse(file.createNewFile("file"));

        }

        [TestMethod]
        public void TestCreateFiledansDirectory()
        {
            Directory dossier = new Directory("dossier", null);
            dossier.chmod("7");
            Assert.IsTrue(dossier.createNewFile("file"));
        }

        [TestMethod]
        public void TestCreateFiledansDirectorySansDroit()
        {
            Directory dossier = new Directory("dossier", null);
            Assert.IsFalse(dossier.createNewFile("file"));
        }

        [TestMethod]
        public void TestCreateFile()
        {
            Directory dossier = new Directory("dossier", null);
            dossier.chmod("7");
            dossier.createNewFile("file");
            Assert.AreEqual(dossier.files[0].Nom, "file");
            Assert.AreEqual(dossier.files.Count, 1);
        }

        [TestMethod]
        public void TestGetNameFile()
        {
            File file = new File("file", null);
            Assert.AreEqual("file", file.getName());
        }

        [TestMethod]
        public void TestGetNamedirectory()
        {
            Directory dossier = new Directory("dossier", null);
            Assert.AreEqual(dossier.getName(), "dossier");
        }

        [TestMethod]
        public void TestgetParentFile()
        {
            Directory dossier = new Directory("dossier", null);
            dossier.chmod("7");
            dossier.createNewFile("file");
            Assert.AreEqual(dossier.files[0].getParent(), dossier);
        }

        [TestMethod]
        public void TestgetParentDirectory()
        {
            Directory dossier = new Directory("dossier", null);
            dossier.chmod("7");
            dossier.mkdir("directory");
            Assert.AreEqual(dossier.files[0].getParent(), dossier);
        }

        [TestMethod]
        public void TestGetRootFile()
        {
            Directory dossier = new Directory("dossier", null);
            dossier.chmod("7");
            dossier.createNewFile("file");
            Assert.AreEqual(dossier.Nom, dossier.files[0].getRoot());
        }

        [TestMethod]
        public void TestGetRootDirectory()
        {
            Directory dossier = new Directory("dossier", null);
            dossier.chmod("7");
            dossier.mkdir("directory");
            Assert.AreEqual(dossier.Nom, dossier.files[0].getRoot());
        }

        [TestMethod]
        public void TestIsDirectory_File()
        {
            File file = new File("file", null);
            Assert.IsFalse(file.isDirectory());
        }

        [TestMethod]
        public void TestIsDirectory_Directory()
        {
            Directory dossier = new Directory("dossier", null);
            Assert.IsTrue(dossier.isDirectory());
        }

        [TestMethod]
        public void TestIsFile_File()
        {
            File file = new File("file", null);
            Assert.IsTrue(file.isFile());
        }

        [TestMethod]
        public void TestIsFile_Directory()
        {
            Directory dossier = new Directory("dossier", null);
            Assert.IsFalse(dossier.isFile());
        }

        [TestMethod]
        public void Testls()
        {
            Directory dossier = new Directory("dossier", null);
            dossier.chmod("7");
            dossier.mkdir("directory");
            dossier.createNewFile("file");
            Assert.AreEqual(dossier.files.Count, 2);
        }

        [TestMethod]
        public void TestMkdirdansFile()
        {
            File file = new File("file", null);
            Assert.IsFalse(file.mkdir("directory"));
        }

        [TestMethod]
        public void TestMkdirdansDirectory()
        {
            Directory dossier = new Directory("dossier", null);
            dossier.chmod("7");
            Assert.IsTrue(dossier.mkdir("dossier"));
        }

        [TestMethod]
        public void TestMkdirdansDirectorysansDroit()
        {
            Directory dossier = new Directory("dossier", null);
            Assert.IsFalse(dossier.createNewFile("file"));
        }

        [TestMethod]
        public void TestMkdir()
        {
            Directory dossier = new Directory("dossier", null);
            dossier.chmod("7");
            dossier.createNewFile("file");
            Assert.AreEqual(dossier.files[0].Nom, "file");
            Assert.AreEqual(dossier.files.Count, 1);
        }

        [TestMethod]
        public void TestDeleteTrue()
        {
            Directory dossier = new Directory("dossier", null);
            dossier.chmod("7");
            dossier.createNewFile("file");
            Assert.IsTrue(dossier.delete("file"));
        }

        [TestMethod]
        public void TestDeleteFalse()
        {
            Directory dossier = new Directory("dossier", null);
            dossier.chmod("7");
            dossier.createNewFile("file");
            Assert.IsFalse(dossier.delete("Fichier"));
        }

        [TestMethod]
        public void TestRenameTo()
        {
            Directory dossier = new Directory("dossier", null);
            dossier.chmod("7");
            dossier.createNewFile("file");
            dossier.renameTo("file","fichier");
            Assert.AreEqual(dossier.files[0].Nom, "fichier");
        }

        [TestMethod]
        public void TestRenameTo_False()
        {
            Directory dossier = new Directory("dossier", null);
            dossier.chmod("7");
            dossier.createNewFile("file");
            dossier.mkdir("Directory");
            Assert.IsFalse(dossier.renameTo("file","Directory"));
        }

        [TestMethod]
        public void TestRenameTo_False2()
        {
            Directory dossier = new Directory("dossier", null);
            dossier.chmod("7");
            dossier.createNewFile("file");
            Assert.IsFalse(dossier.renameTo("Directory", "file"));
        }

        [TestMethod]
        public void TestRenameTo_True()
        {
            Directory dossier = new Directory("dossier", null);
            dossier.chmod("7");
            dossier.createNewFile("file");
            dossier.mkdir("Directory");
            Assert.IsTrue(dossier.renameTo("file", "Fichier"));
        }

        [TestMethod]
        public void TestSearchFileExist()
        {
            Directory dossier = new Directory("dossier", null);
            dossier.chmod("7");
            dossier.createNewFile("file");
            Assert.AreEqual(dossier.search("Fichier").Count, 0);
        }

        [TestMethod]
        public void TestSearchFile()
        {
            Directory dossier = new Directory("dossier", null);
            File file = dossier;
            file.chmod("7");
            file.mkdir("Directory");
            file = file.cd("Directory");
            file.chmod("7");
            file.mkdir("Directory");
            file = file.cd("Directory");
            file.chmod("7");
            file.createNewFile("Directory");

            Assert.AreEqual(dossier.search("Directory").Count, 3);

            
        }

        [TestMethod]
        public void TestGetPath()
        {
            Directory dossier = new Directory("dossier", null);
            File file = dossier;
            dossier.chmod("7");
            dossier.createNewFile("file");
            file = file.cd("file");
            Assert.AreEqual(file.getPath(),"dossier/file");
        }

    }
}
