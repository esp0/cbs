/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Events;

namespace Events.Admin 
{
    public class DataVerifierAdded : IEvent 
    {
        public Guid ProjectId { get; }
        public Guid UserId { get; }

        public DataVerifierAdded (Guid projectId, Guid userId) 
        {
            ProjectId = projectId;
            UserId = userId;
        }
    }
}