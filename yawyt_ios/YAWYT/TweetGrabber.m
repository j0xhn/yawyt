//
//  TweetGrabber.m
//  YAWYT
//
//  Created by Anthony Hart on 8/2/13.
//  Copyright (c) 2013 Ursaware, LLC. All rights reserved.
//

#import "TweetGrabber.h"
#import "TweetModel.h"

@implementation TweetGrabber

+(TweetModel*)MOCK_getRandomTweet:(TweetModel*)currTweet{
	if(currTweet == nil || [currTweet.userFullName isEqualToString:@"Uncle Frank"]){
		return [[TweetModel alloc] initWithText:@"This is a tweet from your Uncle Bob. It's a bit long so we can see how it fits in the UI." andUserFullName:@"Uncle Bob"];
	}
	else if([currTweet.userFullName isEqualToString:@"Uncle Bob"]){
		return [[TweetModel alloc] initWithText:@"This is a tweet from your Uncle Throckmorton. It's a bit long so we can see how it fits in the UI." andUserFullName:@"Uncle Throckmorton"];
	}
	else if([currTweet.userFullName isEqualToString:@"Uncle Throckmorton"]){
		return [[TweetModel alloc] initWithText:@"This is a tweet from your Uncle Remus. It's a bit long so we can see how it fits in the UI." andUserFullName:@"Uncle Remus"];
	}
	else{
		return [[TweetModel alloc] initWithText:@"This is a tweet from your Uncle Frank. It's a bit long so we can see how it fits in the UI." andUserFullName:@"Uncle Frank"];
	}
}

+(NSMutableArray*)MOCK_getRandomUserFullNames{
	NSMutableArray *userFullNames = [[NSMutableArray alloc] initWithCapacity:4];
	
	userFullNames[0] = @"Uncle Remus";
	userFullNames[1] = @"Uncle Bob";
	userFullNames[2] = @"Uncle Frank";
	userFullNames[3] = @"Uncle Throckmorton";
	
	return userFullNames;
}

@end
