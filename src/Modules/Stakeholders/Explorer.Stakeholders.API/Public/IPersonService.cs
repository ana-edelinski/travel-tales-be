﻿using Explorer.Stakeholders.API.Dtos;
using FluentResults;

namespace Explorer.Stakeholders.API.Public;

public interface IPersonService
{
    Result<PersonDto> UpdatePersonEquipment(int id, List<int> equipmentIds);
}


