﻿using YogaCenter.Core.Models;

namespace YogaCenter.Core.Contracts
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentViewModel>> GetAll(int yogaClassId);

        Task Add(CommentViewModel model);

        Task<string> YogaClassName(int yogaClassId);

        Task<string> UserFullName(string userId);
    }
}
