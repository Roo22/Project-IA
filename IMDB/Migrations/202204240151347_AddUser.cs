namespace IMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Actors", "ProfilePictureUrl", c => c.String(nullable: false));
            AlterColumn("dbo.Actors", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Actors", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Actors", "Bio", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Actors", "Bio", c => c.String());
            AlterColumn("dbo.Actors", "LastName", c => c.String());
            AlterColumn("dbo.Actors", "FirstName", c => c.String());
            AlterColumn("dbo.Actors", "ProfilePictureUrl", c => c.String());
        }
    }
}
