using BlazorBootstrap;
using Domain.Entities;
using Domain.Shared;
using Microsoft.AspNetCore.Components;
using Presentation.Utils.ApiClient;
using System.Net;

namespace Presentation.Components.UI.Handbook.HandbookDataTable
{
    public enum TableItemType
    {
        DeviceType,
        Manufacturer
    }

    public class TableItem : HandbookEntity
    {
        public TableItemType ItemType { get; set; }

        public TableItem(DeviceType deviceType)
        {
            ItemType = TableItemType.DeviceType;
            Id = deviceType.Id;
            Name = deviceType.Name;
            Description = deviceType.Description;
            CreatedAt = deviceType.CreatedAt;
            UpdatedAt = deviceType.UpdatedAt;
        }

        public TableItem(Manufacturer manufacturer)
        {
            ItemType = TableItemType.Manufacturer;
            Id = manufacturer.Id;
            Name = manufacturer.Name;
            Description = manufacturer.Description;
            CreatedAt = manufacturer.CreatedAt;
            UpdatedAt = manufacturer.UpdatedAt;
        }

        public async Task Update(Guid id, string? name, string? description)
        {
            var content = JsonContent.Create(new
            {
                Id = id,
                Name = name,
                Description = description
            });

            switch (ItemType)
            {
                case TableItemType.DeviceType:
                    //await ApiClient.PutAsync("api/device-types", content);
                    break;
                case TableItemType.Manufacturer:
                    //await ApiClient.PutAsync("api/manufacturers", content);
                    break;
            }
        }
    }
}
