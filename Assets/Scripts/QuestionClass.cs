// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using Models;
//
//    var question = Question.FromJson(jsonString);

namespace Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Question
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("position")]
        public long Position { get; set; }

        [JsonProperty("door_name")]
        public string DoorName { get; set; }

        [JsonProperty("indice_next")]
        public string IndiceNext { get; set; }

        [JsonProperty("choices")]
        public Choice[] Choices { get; set; }
    }

    public partial class Choice
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("is_right_choice")]
        public bool IsRightChoice { get; set; }

        [JsonProperty("question_id")]
        public long QuestionId { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }

    public partial class Question
    {
        public static Question FromJson(string json) => JsonConvert.DeserializeObject<Question>(json, Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Question self) => JsonConvert.SerializeObject(self, Models.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
