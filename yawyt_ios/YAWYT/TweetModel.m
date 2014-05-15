//
//  TweetModel.m
//  YAWYT
//
//  Created by Anthony Hart on 8/2/13.
//  Copyright (c) 2013 Ursaware, LLC. All rights reserved.
//

#import "TweetModel.h"

@implementation TweetModel

-(id)initWithText:(NSString*)text andUserFullName:(NSString*)userFullName{
	self.text = text;
	self.userFullName = userFullName;
	
	return self;
}

@end
