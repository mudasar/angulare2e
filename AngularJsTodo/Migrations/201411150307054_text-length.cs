namespace AngularJsTodo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class textlength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TodoItems", "Text", c => c.String(maxLength: 800));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TodoItems", "Text", c => c.String());
        }
    }
}
