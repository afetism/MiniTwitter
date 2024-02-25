// See https://aka.ms/new-console-template for more information

using Instagram.Admins;
using Instagram.Users;
using System.Reflection.Metadata;
using System.Xml.Linq;

string[] AccessItem= { "Admin", "User" };
string[] RegisterItem = { "Sign In", "Sign Up" ,"Exit"};
string[] AdminItem  = { "Publish Post", "Show All Post","Nofitaction","Exit" };
string[] LikeItem = { "Like", "Exit" };


void creatMenu(string[] items,int choose)
{
    for (int i = 0; i < items.Length; i++)
    {
        if (i==choose)
        {
            Console.BackgroundColor=ConsoleColor.DarkCyan;
            Console.WriteLine(items[i]);
            Console.ResetColor();
        }
        else
            Console.WriteLine(items[i]);



    }
}
int  MoveInMenu(out int size ,ref int choose, ConsoleKeyInfo keyInfo, string[] items )
{
    size= items.Length;

    if(keyInfo.Key==ConsoleKey.DownArrow)
    {
        if (choose<size-1)
        {
            choose++;
        }
        else if (choose == size-1) choose=0;
    }
    else if (keyInfo.Key==ConsoleKey.UpArrow)
    {
        if (choose>0)
        {
            choose--;
        }
        else if (choose == 0) choose=size-1;
    }
    else if (keyInfo.Key == ConsoleKey.Enter)
    {
        return 1;
    }
    return 0;
}

void ManageAminMenu(string[] items,Admin admin)
{

    AdminMenu:
    int choose = managMenu1(items, admin);
   
    switch((AdminMenu)choose)
    {
        case AdminMenu.PushPost:

            Console.WriteLine("Write Title: ");
            string? title = Console.ReadLine();
            Console.WriteLine("Write post: ");
            string? context=Console.ReadLine();

            if (context is not null && title is not null)
                admin.addPost(context, title);
            else
                goto case AdminMenu.PushPost;
            Console.WriteLine("Back to any Key");
            Console.ReadKey();
            Console.Clear();
            goto AdminMenu;
            break;

            break;
        case AdminMenu.ShowAllPost:
            admin.ShowAllAdminPosts();
            Console.WriteLine("Back to any Key");
            Console.ReadKey();
            Console.Clear();
            goto AdminMenu;
            break;
        case AdminMenu.Nofitaction:
            admin.ShowNotification();
            Console.WriteLine("Back to any Key");
            Console.ReadKey();
            Console.Clear();
            goto AdminMenu;
            break;
        case AdminMenu.Exit:
             
            break;
        default: break;


    }


}


void manageAdmin(string[] items, AdminSytem admin)
{
   
    
    RegisterMenu:
    int choose = managMenu(items);
    if (choose ==0) //sign in
    {
Signin:
        try
        {

            Console.Write("Emailinizi daxil edin:");
            string? email = Console.ReadLine();
            Console.Write("Password daxil edin:");
            string? password = Console.ReadLine();
            Admin currentAdmin = admin.SignIn(email!, password!);
            if (currentAdmin is not null)
            {
                Console.Clear();
                Console.WriteLine("Welcome Back");

                ManageAminMenu(AdminItem, currentAdmin);
                goto RegisterMenu;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Not Exist Email or password!Do you have account?");
                goto RegisterMenu;
            }
        }
        catch (Exception e)
        {
            Console.Clear();
            Console.WriteLine(e.Message);
            goto Signin;

        }
    }
    else if (choose == 1)  //sign up
    {
SignUp:
        try
        {

            Console.Write("Emailinizi daxil edin:");
            string? email = Console.ReadLine();
            Console.Write("Password daxil edin:");
            string? password = Console.ReadLine();
            Console.Write("UserName daxil edin:");
            string? userName = Console.ReadLine();
            Admin admin1 = admin.SignUp(email!, password!, userName!);
            if (admin1 is not null)
            {
                Console.Clear();
                Console.WriteLine("Welcome");
                goto RegisterMenu;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Exist Email or userName!Try again or sign up");
                goto RegisterMenu;
            }
        }
        catch (Exception e)
        {
            Console.Clear();
            Console.WriteLine(e.Message); goto SignUp;
        }
    }
    else
        return;

}

void manageUser(string[] items, AdminSytem adminUser)
{
    UserSystem userSystem = new UserSystem();
    User user = userSystem.SignUp("s", "s", "s", "s", 1);
User:
    int choose = managMenu(items);
    if (choose ==0) //sign in
    {
Signin:
        try
        {

            Console.Write("Emailinizi daxil edin:");
            string? email = Console.ReadLine();
            Console.Write("Password daxil edin:");
            string? password = Console.ReadLine();
            User currentUser = userSystem.SignIn(email!, password!);
            if (currentUser is not null)
            {
                Console.Clear();
                Console.WriteLine("Welcome Back");
                UserPage(adminUser,user);



            }
            else
            {
                Console.Clear();
                Console.WriteLine("Not Exist Email or password!Do you have account?");
                goto User;
            }
        }
        catch (Exception e)
        {
            Console.Clear();
            Console.WriteLine(e.Message);
            goto Signin;

        }
    }
    if (choose == 1)
    {
SignUp:
        try
        {

            Console.Write("Emailinizi daxil edin:");
            string? email = Console.ReadLine();
            Console.Write("Password daxil edin:");
            string? password = Console.ReadLine();
            Console.Write("Name daxil edin:");
            string? name = Console.ReadLine();
            Console.Write("Surname daxil edin:");

            string? surname = Console.ReadLine();
            age:
            Console.Write("Age daxil edin:");
            string? intputAge= Console.ReadLine();
            //User(string name, string surname, int age, string email, string password)
            if (int.TryParse(intputAge, out int age))
            {
                //string email, string password, string surname, string name, int age
                User user1 = userSystem.SignUp(email!,password!,surname!,name!,age);
                if (user1 is not null)
                {
                    Console.Clear();
                    Console.WriteLine("Welcome");
                    goto User;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Exist Email or userName!Try again or sign up");
                    goto User;
                }
            }

        }
        catch (Exception e)
        {
            Console.Clear();
            Console.WriteLine(e.Message); goto SignUp;
        }
  
    }

    else
        return;

}


void manageRegisterMenu(string[] items)
{
    AdminSytem admin = new AdminSytem();
    Admin newAdmin = admin.SignUp("a", "a", "appilona");
    string myText = "Ismayilova Afet Elnur qizi";
    newAdmin.addPost(myText, "My first Post");
AdminorUser:
    int choose = managMenu(items);
    if (choose == 0)
        manageAdmin(RegisterItem,admin);
    else manageUser(RegisterItem,admin);
    goto AdminorUser;
}

int managMenu(string[] items)
{
    int choose = 0;

    creatMenu(items, choose);
    while(true)
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        Console.Clear();
       int _= MoveInMenu(out int size, ref choose, keyInfo, items);
        if (_==0)
            creatMenu(items, choose);
        else if (_==1)
          return choose;



    }
}
int managMenu2(string[] items,string s)
{
    int choose = 0;
    Console.WriteLine(s);
    creatMenu(items, choose);
    while (true)
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        Console.Clear();
        int _ = MoveInMenu(out int size, ref choose, keyInfo, items);
        if (_==0)
        {
            Console.WriteLine(s);
            creatMenu(items, choose);
        }
        else if (_==1)
            return choose;



    }
}

void UserPage(AdminSytem adminSystem,User user)
{
    string[] AdminUserName = adminSystem.getAdminUserName();
    int choose =managMenu(AdminUserName);
    for(int i=0; i<adminSystem.admin.Count; i++)
    {
         if(i==choose)
         {
            string[] _=adminSystem.getPostName(choose);
            int choose1 = managMenu(_);
            string st= adminSystem.getText(choose1,choose);
            int likeChoose = managMenu2(LikeItem,st);
            if (likeChoose==0)
                adminSystem.LikeCount(choose1,user);

        }

    }

}
int managMenu1(string[] items,Admin admin)
{
    int choose = 0;
    Console.WriteLine($"Id.{admin.Id}=>UserName: {admin.UserName}");
    creatMenu(items, choose);
  
    while (true)
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        Console.Clear();
        int _ = MoveInMenu(out int size, ref choose, keyInfo, items);
        if (_==0)
        {
            Console.WriteLine($"Id.{admin.Id}=>UserName: {admin.UserName}");
            creatMenu(items, choose);
        }
        else if (_==1)
            return choose;



    }
}


manageRegisterMenu(AccessItem);


enum AdminMenu
{
    PushPost=0,
    ShowAllPost=1,
    Nofitaction=2,
    Exit

};