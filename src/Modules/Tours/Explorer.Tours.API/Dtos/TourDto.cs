﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos
{
    public class TourDto
    {
        public long Id { get; set; }    

        public string Name { get; set; }
        public string? Description { get; set; }

        public string? Difficulty { get; set; }

        public List<TourTags> Tags { get;  set; }
        public TourStatus Status { get; set; }
        public double Price { get;  set; }
        public long UserId { get;  set; }

        public double LengthInKm { get; set; }

        public List<long> EquipmentIds { get; set; }
        public ICollection<KeyPointDto> KeyPoints { get; set; } = new List<KeyPointDto>();
        public TourDto() { }


        public TourDto(long id, string name, string? description, string? difficulty, List<TourTags> tags, long userId, TourStatus status, double price, double lengthInKm, List<long> equipmentIds, List<long> keyPointIds)

        {
            Id = id;
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Invalid Name.");
            Name = name;
            Description = description;
            Difficulty = difficulty;
            if (tags == null || tags.Count == 0)
            { tags = new List<TourTags>(); }
            Tags = tags;
            if (userId <= 0)
                throw new ArgumentException("Invalid UserId. UserId must be a positive number.");
            UserId = userId;

            Status = status;
            Price = price;
            LengthInKm = lengthInKm;
            EquipmentIds = equipmentIds;

        }
    }

    public enum TourStatus
    {
        Draft,
        Published,
        Archived
    }

    public enum TourTags
    {
        Cycling,
        Culture,
        Adventure,
        FamilyFriendly,
        Nature,
        CityTour,
        Historical,
        Relaxation,
        Wildlife,
        NightTour,
        Beach,
        Mountains,
        Photography,
        Guided,
        SelfGuided
    }
}
