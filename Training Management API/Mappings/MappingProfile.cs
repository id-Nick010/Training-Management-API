using AutoMapper;
using Training_Management_API.DTOs;
using Training_Management_API.Models;

namespace Training_Management_API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            // TrainingProgram map
            CreateMap<TrainingProgram, TrainingProgramDto>()
                .ForMember(dest => dest.TrainerName, opt => opt.MapFrom(src => src.Trainer.Name))
                .ForMember(dest => dest.ParticipantNames, opt => opt.MapFrom(src => src.Participants.Select(p => p.Name).ToList()));

            CreateMap<CreateTrainingDto, TrainingProgram>();

            // Trainer map
            CreateMap<Trainer, TrainerDto>();
            CreateMap<CreateTrainerDto, Trainer>();

            // Participant map
            CreateMap<Participant, ParticipantDto>()
                .ForMember(dest => dest.TrainingTitle, opt => opt.MapFrom(src => src.TrainingProgram.Title));

            CreateMap<CreateParticipantDto, Participant>();
        }
    }
}
