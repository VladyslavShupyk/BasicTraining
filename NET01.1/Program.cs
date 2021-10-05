using NET01._1.Extensions;
using NET01._1.Formats;
using NET01._1.Lessons;
using NET01._1.Materials;
using NET01._1.Versions;
using System;

namespace NET01._1
{
    class Program
    {
        static void Main(string[] args)
        {
            TrainingMaterial material = new VideoMaterial("http://video.com", "http://picture.com", Types.VideoFormat.Mp4);
            TrainingMaterial material2 = new TextMaterial("Hello world!");
            TrainingLesson lesson = new TrainingLesson(material);
            TrainingLesson lesson2 = new TrainingLesson(material2);
            TypeOfLesson type = lesson.GetTypeOfLesson();
            TypeOfLesson type2 = lesson2.GetTypeOfLesson();
            material.SetNewGuidMaterial();
            material2.SetNewGuidMaterial();
            Console.WriteLine("Type first lesson - " + type);
            Console.WriteLine("Description : " + lesson.ToString());
            lesson.SetNewGuidLesson();
            Console.WriteLine(lesson.guid);
            Console.WriteLine("Version of lesson : ");
            IVersionable lesson3 = (TrainingLesson)lesson;
            lesson3.SetVersion(new byte[] { 2, 2, 2, 2, 2, 2, 2, 2 });
            byte[] lesson3Version = lesson3.GetVersion();
            for (int i = 0; i < lesson3Version.Length; i++)
                Console.Write(lesson3Version[i]);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Type second lesson - " + type2);
            Console.WriteLine("Description : " + lesson2.ToString());
            lesson2.SetNewGuidLesson();
            Console.WriteLine(lesson2.guid);
            Console.WriteLine();
            Console.WriteLine("Comparison lessons : ");
            Console.WriteLine("Lesson1 with Lesson1 = " + lesson.Equals(lesson));
            Console.WriteLine("Lesson1 with Lesson2 = " + lesson.Equals(lesson2));
            Console.WriteLine();
            Console.WriteLine("Comparison materials : ");
            Console.WriteLine("Material1 with Material1 = " + material.Equals(material));
            Console.WriteLine("Material1 with Material2 = " + material.Equals(material2));
            Console.WriteLine();
            IVersionable material3 = (VideoMaterial)material;
            byte[] versionMaterial3 = material3.GetVersion();
            Console.Write("Default Version of Material = ");
            for (int i = 0; i < versionMaterial3.Length; i++)
                Console.Write(versionMaterial3[i]);
            Console.WriteLine();
            material3.SetVersion(new byte[]{ 1, 2, 3, 4, 5, 6, 7, 8});
            versionMaterial3 = material3.GetVersion();
            Console.Write("Change Version of Material = ");
            for (int i = 0; i < versionMaterial3.Length; i++)
                Console.Write(versionMaterial3[i]);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Check Clone object TraningVideoLesson : ");
            TrainingLesson newLesson = (TrainingLesson)lesson.Clone();
            VideoMaterial newMaterial = (VideoMaterial)newLesson.material;
            newMaterial.videoUri = "https://video2.com"; //изменяем путь к видео в клоне
            type = newLesson.GetTypeOfLesson();
            Console.WriteLine("Type of lesson - " + type);
            Console.WriteLine("Description of cloned leeson : " + newLesson.ToString());
            Console.WriteLine(newLesson.guid);
            Console.WriteLine("Version of cloned lesson : ");
            lesson3 = (TrainingLesson)newLesson;
            lesson3.SetVersion(new byte[] { 2, 2, 2, 2, 2, 2, 2, 2 });
            lesson3Version = lesson3.GetVersion();
            for (int i = 0; i < lesson3Version.Length; i++)
                Console.Write(lesson3Version[i]);
            Console.WriteLine();
            Console.WriteLine();
            newLesson.SetNewGuidLesson(); //присваеваем новый GUID клону
            Console.WriteLine("New guid for clone lesson - " + newLesson.guid); //Проверка изменился ли guid только в клоне или же и в клоне и в изначальном уроке.
            Console.WriteLine("Guid of lesson - " + lesson.guid);
        }
    }
}
