﻿/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated Command Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { Command } from  '@dolittle/commands';

export class CreateAlertRule extends Command
{
    constructor() {
        super();
        this.type = '3cb24b12-3394-414b-af61-6ba3ee315358';

        this.id = '00000000-0000-0000-0000-000000000000';
        this.alertRuleName = '';
        this.numberOfCasesThreshold = 0;
        this.thresholdTimeframeInHours = 0;
        this.healthRiskNumber = 0;
        this.distanceBetweenCasesInMeters = 0;
    }
}