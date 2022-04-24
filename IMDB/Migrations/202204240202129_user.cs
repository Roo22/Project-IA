namespace IMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        ProfilePictureUrl = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        FavActor_ActorId = c.Int(),
                        FavDirector_DirectorId = c.Int(),
                        FavMovie_MovieId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Actors", t => t.FavActor_ActorId)
                .ForeignKey("dbo.Directors", t => t.FavDirector_DirectorId)
                .ForeignKey("dbo.Movies", t => t.FavMovie_MovieId)
                .Index(t => t.FavActor_ActorId)
                .Index(t => t.FavDirector_DirectorId)
                .Index(t => t.FavMovie_MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "FavMovie_MovieId", "dbo.Movies");
            DropForeignKey("dbo.Users", "FavDirector_DirectorId", "dbo.Directors");
            DropForeignKey("dbo.Users", "FavActor_ActorId", "dbo.Actors");
            DropIndex("dbo.Users", new[] { "FavMovie_MovieId" });
            DropIndex("dbo.Users", new[] { "FavDirector_DirectorId" });
            DropIndex("dbo.Users", new[] { "FavActor_ActorId" });
            DropTable("dbo.Users");
        }
    }
}
