using GymSystemAPI.Models.Domain;
using GymSystemAPI.Models.Dto;
using GymSystemAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymSystemAPI.Controllers.API.Trainer
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private static List<ExerciseDto> ListExercises = new List<ExerciseDto>()
        {
            new ExerciseDto()
            {
               Musclename="chest",
               Exercises=
                 "Dumbbell press lying,Machine assembly,Hammer chest compression (top),Hammer chest compressio,Dumbbell set up, Paul Over Reel"
                 

            },

             new ExerciseDto()
            {
               Musclename="Hands front",
               Exercises=
                 "z-bar, focus ready Dumbbell,Standing hammer exchange",
             },
                   


         

               new ExerciseDto()
            {
               Musclename="Hands back",
               Exercises=
                 "Push down rope standing,Standing dumbbell crunch,Dumbbell lying towards chest",

                   


            },

               new ExerciseDto()
            {
               Musclename="epaulet",
               Exercises=
                 "higher pressure in the machine,Dumbbell side flap,Front bar flapping,flutter sideways sitting on the machine,Rear flap on the engine",




            },

               new ExerciseDto()
            {
               Musclename="Arms",
               Exercises=
                 "Swing in front of me with the bar,z-bar",




            },

               new ExerciseDto()
            {
               Musclename="Legs",
               Exercises=
                 "piston,front table,back table,open table,closed table,Sitting ducks",




            },

               new ExerciseDto()
            {
               Musclename="back",
               Exercises=
                 "Seated Cable Pulldown Wide Grip,Seated Reverse Grip Cable Pull,Rowing on the device,Withdraw on the device,Roman chair,front shrug with bar",




            }
        };
        public CourseController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost("Exersices")]
        public async Task<IActionResult> SaveExercises()
        {
            foreach (var exerciseDto in ListExercises)
            {
                // Check if the ExerciseDto already exists in the database
                var existingExerciseDto = await _context.exersices.FirstOrDefaultAsync(e => e.Musclename == exerciseDto.Musclename);
                if (existingExerciseDto == null)
                {
                    // Convert the list of exercises to a comma-separated string
                    var exercisesString = string.Join(",", exerciseDto.Exercises);

                    // Create a new ExerciseDto entity and save it to the database
                    var newExerciseDto = new Exersice
                    {
                        Musclename = exerciseDto.Musclename,
                        Exercises = exercisesString
                    };
                    _context.exersices.Add(newExerciseDto);
                }
                else
                {
                    // Update the existing ExerciseDto with the new exercises
                    existingExerciseDto.Exercises = string.Join(",", exerciseDto.Exercises);
                    _context.exersices.Update(existingExerciseDto);
                }
            }

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("Course")]

        public IActionResult AddCourse(int? userId,int id,CourseDto courseDto)
        {
            var course = new Course
            {
                FirstDay = courseDto.FirstDay,
                SecondDay = courseDto.SecondDay,
                ThirdDay = courseDto.ThirdDay,
                ForthDay = courseDto.ForthDay,
                FifthDay = courseDto.FifthDay,
                Exerciseid = id,
                UserId = userId
            };
            _context.courses.Add(course);
            _context.SaveChanges();
            return Ok(course);

        }

        [HttpGet("courses")]
        public IActionResult GetCourses()
        {
            var listcourses = _context.courses.ToList();
            return Ok(listcourses);
        }


    }
}