namespace AngularJsTodo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seed1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TodoItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Priority = c.Int(nullable: false),
                        DueDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TodoItems");
        }
    }
}
