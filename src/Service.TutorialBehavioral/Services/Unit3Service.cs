﻿using System.Threading.Tasks;
using Service.Core.Client.Education;
using Service.TutorialBehavioral.Grpc.Models;
using Service.TutorialBehavioral.Grpc.Models.State;
using static Service.TutorialBehavioral.Services.AnswerHelper;

namespace Service.TutorialBehavioral.Services
{
	public partial class TutorialBehavioralService
	{
		public static readonly EducationStructureUnit Unit3 = Tutorial.Units[3];

		public async ValueTask<TestScoreGrpcResponse> Unit3TextAsync(BehavioralTaskTextGrpcRequest request) => 
			await _taskProgressService.SetTaskProgressAsync(request.UserId, Unit3, Unit3.Tasks[1], request.IsRetry, request.Duration);

		public async ValueTask<TestScoreGrpcResponse> Unit3TestAsync(BehavioralTaskTestGrpcRequest request)
		{
			BehavioralTaskTestAnswerGrpcModel[] answers = request.Answers;

			int progress = CheckAnswer(20, answers, 1, 2)
				+ CheckAnswer(20, answers, 2, 2)
				+ CheckAnswer(20, answers, 3, 2)
				+ CheckAnswer(20, answers, 4, 2)
				+ CheckAnswer(20, answers, 5, 2);

			return await _taskProgressService.SetTaskProgressAsync(request.UserId, Unit3, Unit3.Tasks[2], request.IsRetry, request.Duration, progress);
		}

		public async ValueTask<TestScoreGrpcResponse> Unit3VideoAsync(BehavioralTaskVideoGrpcRequest request) => 
			await _taskProgressService.SetTaskProgressAsync(request.UserId, Unit3, Unit3.Tasks[3], request.IsRetry, request.Duration);

		public async ValueTask<TestScoreGrpcResponse> Unit3CaseAsync(BehavioralTaskCaseGrpcRequest request) => 
			await _taskProgressService.SetTaskProgressAsync(request.UserId, Unit3, Unit3.Tasks[4], request.IsRetry, request.Duration, CountProgress(request.Value == 1));

		public async ValueTask<TestScoreGrpcResponse> Unit3TrueFalseAsync(BehavioralTaskTrueFalseGrpcRequest request)
		{
			BehavioralTaskTrueFalseAnswerGrpcModel[] answers = request.Answers;

			int progress = CheckAnswer(20, answers, 1, false)
				+ CheckAnswer(20, answers, 2, true)
				+ CheckAnswer(20, answers, 3, true)
				+ CheckAnswer(20, answers, 4, true)
				+ CheckAnswer(20, answers, 5, true);

			return await _taskProgressService.SetTaskProgressAsync(request.UserId, Unit3, Unit3.Tasks[5], request.IsRetry, request.Duration, progress);
		}

		public async ValueTask<TestScoreGrpcResponse> Unit3GameAsync(BehavioralTaskGameGrpcRequest request) => 
			await _taskProgressService.SetTaskProgressAsync(request.UserId, Unit3, Unit3.Tasks[6], request.IsRetry, request.Duration);
	}
}