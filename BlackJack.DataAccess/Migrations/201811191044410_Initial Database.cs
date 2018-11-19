namespace BlackJack.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeckCard",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CardSuit = c.Int(nullable: false),
                        CardNumber = c.Int(nullable: false),
                        CardScore = c.Int(nullable: false),
                        CardName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlayerHand",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        Cash = c.Int(nullable: false),
                        CardPoints = c.Int(nullable: false),
                        PlayerId = c.Long(nullable: false),
                        StepId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlayerHandCard",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PlayerHandId = c.Long(nullable: false),
                        CardId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Step",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        WinnerId = c.Long(nullable: false),
                        GameId = c.Long(nullable: false),
                        GameProcess = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        SelectedBots = c.Int(nullable: false),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            AddForeignKey("Game", "UserId", "User", principalColumn: "Id");
            AddForeignKey("Step", "GameId", "Game", principalColumn: "Id");
            AddForeignKey("PlayerHand", "StepId", "Step", principalColumn: "Id");
            AddForeignKey("PlayerHand", "PlayerId", "User", principalColumn: "Id");
            AddForeignKey("PlayerHandCard", "PlayerHandId", "PlayerHand", principalColumn: "Id");
            AddForeignKey("PlayerHandCard", "CardId", "DeckCard", principalColumn: "Id");
        }

        public override void Down()
        {
            DropForeignKey("DeckCard", "Id", "PlayerHandCard");
            DropForeignKey("PlayerHand", "Id", "PlayerHandCard");
            DropForeignKey("User", "Id", "PlayerHand");
            DropForeignKey("PlayerHand", "StepId", "Step");
            DropForeignKey("Step", "GameId", "Game");
            DropForeignKey("Game", "UserId", "User");

            DropTable("dbo.User");
            DropTable("dbo.Step");
            DropTable("dbo.PlayerHandCard");
            DropTable("dbo.PlayerHand");
            DropTable("dbo.Game");
            DropTable("dbo.DeckCard");
        }
    }
}
