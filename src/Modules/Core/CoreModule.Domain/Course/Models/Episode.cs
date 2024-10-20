﻿using Common.L1.Domain;
using Common.L1.Domain.Exceptions;
using Common.L1.Domain.Utilities;

namespace CoreModule.Domain.Course.Models;

public class Episode : BaseEntity
{
    public string Title { get; private set; }
    public string EnglishTitle { get; private set; }
    public Guid SectionId { get; private set; }
    public Guid Token { get; private set; }
    public TimeSpan TimeSpan { get; private set; }
    public string VideoName { get; private set; }
    public string? AttachmentName { get; private set; }
    public bool IsActive { get; private set; }
    public bool IsFree { get; private set; }

    public Episode(string? attachmentName, string videoName, TimeSpan timeSpan, Guid token, string title, bool isActive, bool isFree, Guid sectionId, string englishTitle)
    {
        Guard(videoName, englishTitle, title);

        IsActive = isActive;
        SectionId = sectionId;
        EnglishTitle = englishTitle;
        AttachmentName = attachmentName;
        VideoName = videoName;
        TimeSpan = timeSpan;
        Token = token;
        Title = title;
        IsFree = isFree;
    }

    public void ToggleStatus()
    {
        IsActive = !IsActive;
    }

    void Guard(string videoName, string englishTitle, string title)
    {
        NullOrEmptyDomainDataException.CheckString(videoName, nameof(videoName));
        NullOrEmptyDomainDataException.CheckString(englishTitle, nameof(englishTitle));
        NullOrEmptyDomainDataException.CheckString(title, nameof(title));
        if (englishTitle.IsUniCode())
        {
            throw new InvalidDomainDataException("Invalid EnglishTitle");
        }
    }
}