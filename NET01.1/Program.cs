using NET01._1.Extensions;
using NET01._1.Formats;
using NET01._1.Lessons;
using NET01._1.Materials;
using System;

namespace NET01._1
{
    class Program
    {
        static void Main(string[] args)
        {
            TrainingMaterial material1 = new TextMaterial("Text Material 1", "Text Material");
            TrainingMaterial material2 = new VideoMaterial("https://video1.com","https://picture1.com",Types.VideoFormat.Mp4,"Video Material");
            TrainingLesson lesson1 = new TrainingLesson("Training Lesson 1",material1,material2);
            lesson1.SetNewGuidLesson();
            ShowInfoAboutLesson(lesson1);
            ShowInfoAboutMaterialsInLesson(lesson1);
            TrainingLesson lessonClone = (TrainingLesson)lesson1.Clone();
            Console.WriteLine("Some changes in cloned lesson");
            lessonClone.SetNewGuidLesson();
            VideoMaterial videoMaterial = (VideoMaterial)lessonClone.materials[1];
            videoMaterial.VideoUri = "https://video2.com";
            videoMaterial.PictureUri = "https://picture2.com";
            videoMaterial.SetNewGuidMaterial();
            lessonClone.Description = "Cloned lesson description";
            byte[] newVersion = new byte[] { 1, 1, 1, 1, 1, 1, 1, 1 };
            lessonClone.SetVersion(newVersion);
            Console.WriteLine("SOURCE LESSON INFO : ");
            ShowInfoAboutLesson(lesson1);
            ShowInfoAboutMaterialsInLesson(lesson1);
            Console.WriteLine("CLONED LESSON INFO: ");
            ShowInfoAboutLesson(lessonClone);
            ShowInfoAboutMaterialsInLesson(lessonClone);
        }
        static void ShowInfoAboutMaterialsInLesson(TrainingLesson lesson)
        {
            for (int i = 0; i < lesson.materials.Length; i++)
            {
                if(lesson.materials[i].GetType() == typeof(TextMaterial))
                {
                    TextMaterial material = (TextMaterial)lesson.materials[i];
                    Console.WriteLine("Material description : " + material.Description);
                    Console.WriteLine("Material Text : " + material.Text);
                    Console.WriteLine("Material GUID : " + material.guid);
                    Console.WriteLine();
                }
                else if(lesson.materials[i].GetType() == typeof(VideoMaterial))
                {
                    VideoMaterial material = (VideoMaterial)lesson.materials[i];
                    Console.WriteLine("Material description : " + material.Description);
                    Console.WriteLine("Material VideoUri : " + material.VideoUri);
                    Console.WriteLine("Material PictureUri : " + material.PictureUri);
                    Console.WriteLine("Material format : " + material.Format);
                    Console.WriteLine("Material GUID : " + material.guid);
                    Console.WriteLine();
                }
                else
                {
                    UriMaterial material = (UriMaterial)lesson.materials[i];
                    Console.WriteLine("Material description : " + material.Description);
                    Console.WriteLine("Material Uri : " + material.Uri);
                    Console.WriteLine("Material format : " + material.Format);
                    Console.WriteLine("Material GUID : " + material.guid);
                    Console.WriteLine();
                }
            }
        }
        static void ShowInfoAboutLesson(TrainingLesson lesson)
        {
            TypeLesson typeLesson = lesson.GetLessonType();
            Console.WriteLine(lesson.ToString());
            Console.WriteLine("Type of lesson - " + typeLesson);
            Console.Write("Lesson Matrials : ");
            for (int i = 0; i < lesson.materials.Length; i++)
            {
                if(i != lesson.materials.Length - 1)
                    Console.Write(lesson.materials[i].ToString() + ", ");
                else
                    Console.Write(lesson.materials[i].ToString());
            }
            Console.WriteLine();
            Console.WriteLine("Lesson guid  - " + lesson.guid);
            Console.Write("Lesson version - ");
            byte[] version = lesson.GetVersion();
            for (int i = 0; i < version.Length; i++)
            {
                Console.Write(version[i]);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
