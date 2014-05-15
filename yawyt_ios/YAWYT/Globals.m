//
//  Globals.m
//  YAWYT
//
//  Created by Anthony Hart on 8/2/13.
//  Copyright (c) 2013 Ursaware, LLC. All rights reserved.
//

#import "Globals.h"

@implementation Globals

static NSString *currUserName = @"";
static NSString *currPassword = @"";

+(void)setCurrUserName:(NSString *)userName andPassword:(NSString *)password{
	currUserName = userName;
	currPassword = password;
}

+(void)clearCurrUserInfo{
	currUserName = @"";
	currPassword = @"";
}

+(BOOL)isUserSignedIn{
	return
		(currUserName != nil) && (![currUserName isEqualToString:@""]) &&
		(currPassword != nil) && (![currPassword isEqualToString:@""]);
}

@end
