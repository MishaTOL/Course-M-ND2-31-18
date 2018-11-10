using AutoMapper;
using RepositoryModels;
using ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Initializer
    {
        public static void Initialize()
        {
            InitializeAutomapper();
        }

        private static void InitializeAutomapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<StudentEntity, StudentInfo>();
                cfg.CreateMap<StudentInfo, StudentEntity>();
                cfg.CreateMap<PostEntity, PostInfo>();
                cfg.CreateMap<PostInfo, PostEntity>();
                cfg.CreateMap<CommentEntity, CommentInfo>();
                cfg.CreateMap<CommentInfo, CommentEntity>();
                cfg.CreateMap<TagEntity, TagInfo>();
                cfg.CreateMap<TagInfo, TagEntity>();
                cfg.CreateMap<TagPostMap, TagPostMapInfo>();
                cfg.CreateMap<TagPostMapInfo, TagPostMap>();
            });
        }
    }
}
