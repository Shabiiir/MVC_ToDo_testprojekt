namespace MyFirstMVCProjekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPostClass : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ToDoItems", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.ToDoItems", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ToDoItems", "Description", c => c.String());
            AlterColumn("dbo.ToDoItems", "Title", c => c.String());
        }
    }
}
