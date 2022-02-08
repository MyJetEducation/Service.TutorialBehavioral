﻿using System;
using System.Runtime.Serialization;

namespace Service.TutorialBehavioral.Grpc.Models
{
	[DataContract]
	public class BehavioralRetryTaskGrpcRequest
	{
		[DataMember(Order = 1)]
		public Guid? UserId { get; set; }

		[DataMember(Order = 2)]
		public int Unit { get; set; }

		[DataMember(Order = 3)]
		public int Task { get; set; }
	}
}