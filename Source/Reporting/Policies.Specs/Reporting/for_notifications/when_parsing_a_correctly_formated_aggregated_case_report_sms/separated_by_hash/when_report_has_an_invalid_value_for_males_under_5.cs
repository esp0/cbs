/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Events.NotificationGateway.Reporting.SMS;
using Machine.Specifications;
using Policies.Reporting.Notifications;
using Policies.Specs.Reporting.for_notifications.when_parsing_a_correctly_formated_aggregated_case_report_sms.separated_by_hash.given;

namespace Policies.Specs.Reporting.for_notifications.when_parsing_a_correctly_formated_aggregated_case_report_sms.separated_by_hash
{
    [Subject("Notification")]
    public class when_report_has_an_invalid_value_for_males_under_5 : text_message_received_events_containing_aggregated_case_report
    {        
        static readonly NotificationParser parser = new NotificationParser();
        static TextMessageReceived received_text_message;
        static NotificationParsingResult result;
        Establish context = () => received_text_message = text_message_received_with_invalid_cases_of_male_under_5();
        
        Because of = () => result = parser.Parse(received_text_message);

        It should_not_be_a_valid_case_report = () => result.IsValid.ShouldBeFalse();
        It should_have_1_error_message = () => result.ErrorMessages.Count.ShouldEqual(1);
        It should_not_be_a_valid_format = () => result.IsInvalidFormat.ShouldBeTrue();
    }
}