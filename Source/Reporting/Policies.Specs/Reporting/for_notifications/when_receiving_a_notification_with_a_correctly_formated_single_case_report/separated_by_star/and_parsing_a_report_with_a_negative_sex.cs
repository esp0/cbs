/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Events.NotificationGateway.Reporting.SMS;
using Machine.Specifications;
using Policies.Reporting.Notifications;

namespace Policies.Specs.Reporting.for_notifications.when_receiving_a_notification_with_a_correctly_formated_single_case_report.separated_by_star
{
    [Subject("Notification")]
    public class and_parsing_a_report_with_a_negative_sex : given.a_text_message_received_builder_for_single_case_report_separated_by_star
    {
        static readonly NotificationParser parser = new NotificationParser();
        static TextMessageReceived received_text_message;
        static NotificationParsingResult result;
        Establish context = () => received_text_message = text_message_received_with_negative_sex(false);
        
        Because of = () => result = parser.Parse(received_text_message);

        It should_not_be_a_valid_case_report = () => result.IsValid.ShouldBeFalse();
        It should_have_two_error_messages = () => result.ErrorMessages.Count.ShouldEqual(2);
        It should_be_a_valid_format = () => result.IsInvalidFormat.ShouldBeFalse();
        It should_a_human_case_report = () => result.IsNonHumanCaseReport.ShouldBeFalse();
        It should_be_a_single_case_report = () => result.IsSingleCaseReport.ShouldBeTrue();
        It should_not_be_a_multiple_case_report = () => result.IsMultipleCaseReport.ShouldBeFalse();
    }
}