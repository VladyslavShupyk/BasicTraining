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
            //Text lesson test
            TrainingLesson textLesson = new TrainingLesson(new TextMaterial("Lorem ipsum...","First text lesson"));
            textLesson.Description = "First lesson";
            textLesson.SetNewGuidLesson();
            textLesson.material.SetNewGuidMaterial();
            byte[] textLessonVersion = new byte[] { 1, 1, 1, 1, 1, 1, 1, 1};
            textLesson.SetVersion(textLessonVersion);
            ShowInfoAboutLesson(textLesson);

            //Clone text lesson test
            TrainingLesson cloneTextLesson = (TrainingLesson)textLesson.Clone();
            Console.WriteLine("Testing the Equality of Lessons : "); 
            if (textLesson.Equals(cloneTextLesson))
                Console.WriteLine("Lessons are the same");
            else
                Console.WriteLine("Lessons are not the same");
            Console.WriteLine();
            cloneTextLesson.Description = "Clone first lesson";
            cloneTextLesson.material.Description = "Clone first text lesson";
            cloneTextLesson.SetNewGuidLesson();
            cloneTextLesson.material.SetNewGuidMaterial();
            byte[] cloneLessonVersion = new byte[] { 2, 2, 2, 2, 2, 2, 2, 2 };
            cloneTextLesson.SetVersion(cloneLessonVersion);
            ShowInfoAboutLesson(cloneTextLesson);
            Console.WriteLine("Testing the Equality of Lessons after changes : "); 
            if (textLesson.Equals(cloneTextLesson))
                Console.WriteLine("Lessons are the same");
            else
                Console.WriteLine("Lessons are not the same");
            Console.WriteLine();
            //Test video lesson
            TrainingLesson videoLesson = new TrainingLesson(new VideoMaterial("http://video.com", "http://picture.com", Types.VideoFormat.Mp4, "First video lesson"));
            videoLesson.Description = "Second lesson";
            videoLesson.SetNewGuidLesson();
            videoLesson.material.SetNewGuidMaterial();
            byte[] videoLessonVersion = new byte[] {3, 3, 3, 3, 3, 3, 3, 3};
            byte[] videoVersion = new byte[] { 4, 4, 4, 4, 4, 4, 4, 4};
            videoLesson.SetVersion(videoLessonVersion);
            VideoMaterial videoMaterial = (VideoMaterial)videoLesson.material;
            videoMaterial.SetVersion(videoVersion);
            ShowInfoAboutLesson(videoLesson);

            

        }
        static void ShowInfoAboutLesson(TrainingLesson lesson)
        {
            TypeOfLesson typeOfLesson = lesson.GetTypeOfLesson();
            Console.WriteLine(lesson.ToString());
            Console.WriteLine("Type of lesson - " + typeOfLesson);
            Console.WriteLine("Description of material lesson - " + lesson.material.ToString());
            Console.WriteLine("Lesson GUID - " + lesson.guid);
            Console.WriteLine("Material GUID - " + lesson.material.guid);
            byte [] version = lesson.GetVersion();
            string lessonVersion = String.Empty;
            for (int i = 0; i < version.Length; i++)
                lessonVersion += version[i];
            Console.WriteLine("Lesson version - " + lessonVersion);
            if(typeOfLesson == TypeOfLesson.VideoLesson)
            {
               VideoMaterial material = (VideoMaterial)lesson.material;
               byte[] videoLessonVersion = material.GetVersion();
               string videoVersion = String.Empty;
               for (int i = 0; i < videoLessonVersion.Length; i++)
                    videoVersion += videoLessonVersion[i];
                Console.WriteLine("VideoMaterial version - " + videoVersion);
            }
            Console.WriteLine();
        }
    }
}
