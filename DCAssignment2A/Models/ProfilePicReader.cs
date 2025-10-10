namespace DCAssignment2A.Models
{
    public class ProfilePicReader
    {
        //setting the default byte[] of userprofile
        //the output on swagger's json is extremely massive though.
        public static byte[] GetDefaultPFP()
        {
            string filepath = Path.Combine(AppContext.BaseDirectory, "Resources", "default.jpg");
            return File.ReadAllBytes(filepath);
        }

        //perhaps we can change the byte[] field to just a string thats the name aka default.jpg
        // and then do userprofile.pfp as a parameter for this method to return a byte array? or return an actual Image for display?
        //if we go this path change in userprofilecontroller the post method and the getting pfp method to accomodate
        //???
        //otherwise tbh we can use this method below to just get the byte[] of other images that we might add to give variety to user pfps to return to userprofile []
        public static byte[] GetPFP(string pfp)
        {
            string filepath = Path.Combine(AppContext.BaseDirectory, "Resources", pfp);
            return File.ReadAllBytes(filepath);
        }
    }
}
