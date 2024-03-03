// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("Hj5LJm6iZuiMNOH0hV/i70hR35KjORz+EquK/bbkBA9Wq8n6VSQFSLACgaKwjYaJqgbIBneNgYGBhYCDAVTT762Ym7UxtTP8l3bGvv56z1bG/KiNMgdtICNVkqB06fnzYP4hlOymjvkCmodh8MVvQ8S8z7u2vm/eauerdVmORZalN8cpufzaaaP/1c6H/zyI90csZ/OWfNzVwyUgnHXjLdkZh+EIPic3lUzZ5DrEomX9RbMqAoGPgLACgYqCAoGBgCJwscfoaQANdRm17Gm2szaOTEtuVXoke27t3mnFBDLlD34oiMoQKXCQyxmRa8kfRJgnX2dD0OQYtZ+/mGtYZ8LH0pYTp75ZCd06q43GSmjWgUWLAeS3ErbQbDBt38u63YKDgYCB");
        private static int[] order = new int[] { 12,5,12,10,4,13,7,7,12,13,11,12,13,13,14 };
        private static int key = 128;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
