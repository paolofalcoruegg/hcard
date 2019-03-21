
% read data files
user_data = csvread('user_dataswiss.txt');
path_data = csvread('Path data - Sheet1.csv');

%user variables
timeuser = user_data(1:1283,1);
alpha = user_data(1:1283,2);
beta = user_data(1:1283,3);
yuser = user_data(1:1283,4);
xuser = user_data(1:1283,5);

%path variables
ypath = path_data(1:end,3);
xpath = path_data(1:end,2);
timepath = path_data(1:end,1);

%left right angles 
time_angle1r = 0;
time_angle2r = 0;
time_angle3r = 0;
time_angle4r = 0;
time_angle1l = 0;
time_angle2l = 0;
time_angle3l = 0;
time_angle4l = 0;
%front back angles
time_angle1f = 0;
time_angle2f = 0;
time_angle3f = 0;
time_angle4f = 0;
time_angle1b = 0;
time_angle2b = 0;
time_angle3b = 0;
time_angle4b = 0;


%path function
fitpath = fit(xpath,ypath,'linearinterp');


%level difficulty
difficulty = 'N/A';
diff_value = user_data(1, 6);
%calculate time spent at each angle
if (diff_value == 5)
    difficulty = 'Easy';
     for i=1:1283
        if (1 < alpha(i)) && ( alpha(i) < 2.5)
            time_angle1r = time_angle1r + 0.1;
        end
        if (2.5 < alpha(i)) && ( alpha(i) < 4)
            time_angle2r = time_angle2r + 0.1;
        end
        if (4 < alpha(i)) && ( alpha(i) < 5.5)
            time_angle3r = time_angle3r + 0.1;
        end
        if (5.5 < alpha(i)) && ( alpha(i) < 7)
            time_angle4r = time_angle4r + 0.1;
        end
        if (-2.5 < alpha(i)) && ( alpha(i) < -1)
            time_angle1l = time_angle1l + 0.1;
        end
        if (-4 < alpha(i)) && ( alpha(i) < -2.5)
            time_angle2l = time_angle2l + 0.1;
        end
        if (-5.5 < alpha(i)) && ( alpha(i) < -4)
            time_angle3l = time_angle3l + 0.1;
        end
        if (-7 < alpha(i)) && ( alpha(i) < -5.5)
            time_angle4l = time_angle4l + 0.1;
        end
     end
end
if (diff_value == 3)
    difficulty = 'Medium';
    for i=1:1283
        if (2 < alpha(i)) && ( alpha(i) < 4.5)
            time_angle1r = time_angle1r + 0.1;
        end
        if (4.5 < alpha(i)) && ( alpha(i) < 7)
            time_angle2r = time_angle2r + 0.1;
        end
        if (7 < alpha(i)) && ( alpha(i) < 9.5)
            time_angle3r = time_angle3r + 0.1;
        end
        if (9.5 < alpha(i)) && ( alpha(i) < 11)
            time_angle4r = time_angle4r + 0.1;
        end
        if (-4.5 < alpha(i)) && ( alpha(i) < -2)
            time_angle1l = time_angle1l + 0.1;
        end
        if (-7 < alpha(i)) && ( alpha(i) < -4.5)
            time_angle2l = time_angle2l + 0.1;
        end
        if (-9.5 < alpha(i)) && ( alpha(i) < -7)
            time_angle3l = time_angle3l + 0.1;
        end
        if (-11 < alpha(i)) && ( alpha(i) < -9.5)
            time_angle4l = time_angle4l + 0.1;
        end
    end
end
if (diff_value == 2)
    difficulty = 'Hard';
     for i=1:1283
        if (3 < alpha(i)) && ( alpha(i) < 7)
            time_angle1r = time_angle1r + 0.1;
        end
        if (7 < alpha(i)) && ( alpha(i) < 10)
            time_angle2r = time_angle2r + 0.1;
        end
        if (10 < alpha(i)) && ( alpha(i) < 13)
            time_angle3r = time_angle3r + 0.1;
        end
        if (13 < alpha(i)) && ( alpha(i) < 16)
            time_angle4r = time_angle4r + 0.1;
        end
        if (-7 < alpha(i)) && ( alpha(i) < -3)
            time_angle1l = time_angle1l + 0.1;
        end
        if (-10 < alpha(i)) && ( alpha(i) < -7)
            time_angle2l = time_angle2l + 0.1;
        end
        if (-13 < alpha(i)) && ( alpha(i) < -10)
            time_angle3l = time_angle3l + 0.1;
        end
        if (-16 < alpha(i)) && ( alpha(i) < -13)
            time_angle4l = time_angle4l + 0.1;
        end
     end
end
 score_angle1r = (time_angle1r/6)*100;
    if score_angle1r > 100
        score_angle1r = 100;     
    end
    score_angle2r = (time_angle2r/10)*100;
    if score_angle2r > 100
        score_angle2r = 100;     
    end
    score_angle3r = (time_angle3r/4)*100;
    if score_angle3r > 100
        score_angle3r = 100;     
    end
    score_angle4r = (time_angle4r/7)*100;
    if score_angle4r > 100
        score_angle4r = 100;     
    end
    score_angle1l = (time_angle1l/6)*100;
    if score_angle1l > 100
        score_angle1l = 100;     
    end
    score_angle2l = (time_angle2l/10)*100;
    if score_angle2l > 100
        score_angle2l = 100;     
    end
    score_angle3l = (time_angle3l/4)*100;
    if score_angle3l > 100
        score_angle3l = 100;     
    end
    score_angle4l = (time_angle4l/7)*100;
    if score_angle4l > 100
        score_angle4l = 100;     
    end
if (diff_value == 5)
    difficulty = 'Easy';
     for i=1:1283
        if (1 < beta(i)) && ( beta(i) < 2.5)
            time_angle1f = time_angle1f + 0.1;
        end
        if (2.5 < beta(i)) && ( beta(i) < 4)
            time_angle2f = time_angle2f + 0.1;
        end
        if (4 < beta(i)) && ( beta(i) < 5.5)
            time_angle3f = time_angle3f + 0.1;
        end
        if (5.5 < beta(i)) && ( beta(i) < 7)
            time_angle4f = time_angle4f + 0.1;
        end
        if (-2.5 < beta(i)) && ( beta(i) < -1)
            time_angle1b = time_angle1b + 0.1;
        end
        if (-4 < beta(i)) && ( beta(i) < -2.5)
            time_angle2b = time_angle2b + 0.1;
        end
        if (-5.5 < beta(i)) && ( beta(i) < -4)
            time_angle3b = time_angle3b + 0.1;
        end
        if (-7 < beta(i)) && ( beta(i) < -5.5)
            time_angle4b = time_angle4b + 0.1;
        end
     end
end
if (diff_value == 3)
    difficulty = 'Medium';
    for i=1:1283
        if (2 < beta(i)) && ( beta(i) < 4.5)
            time_angle1f = time_angle1f + 0.1;
        end
        if (4.5 < beta(i)) && ( beta(i) < 7)
            time_angle2f = time_angle2f + 0.1;
        end
        if (7 < beta(i)) && ( beta(i) < 9.5)
            time_angle3f = time_angle3f + 0.1;
        end
        if (9.5 < beta(i)) && ( beta(i) < 11)
            time_angle4f = time_angle4f + 0.1;
        end
        if (-4.5 < beta(i)) && ( beta(i) < -2)
            time_angle1b = time_angle1b + 0.1;
        end
        if (-7 < beta(i)) && ( beta(i) < -4.5)
            time_angle2b = time_angle2b + 0.1;
        end
        if (-9.5 < beta(i)) && ( beta(i) < -7)
            time_angle3b = time_angle3b + 0.1;
        end
        if (-11 < beta(i)) && ( beta(i) < -9.5)
            time_angle4b = time_angle4b + 0.1;
        end
    end
end
if (diff_value == 2)
    difficulty = 'Hard';
     for i=1:1283
        if (3 < beta(i)) && ( beta(i) < 7)
            time_angle1f = time_angle1f + 0.1;
        end
        if (7 < beta(i)) && ( beta(i) < 10)
            time_angle2f = time_angle2f + 0.1;
        end
        if (10 < beta(i)) && ( beta(i) < 13)
            time_angle3f = time_angle3f + 0.1;
        end
        if (13 < beta(i)) && ( beta(i) < 17)
            time_angle4f = time_angle4f + 0.1;
        end
        if (-7 < beta(i)) && ( beta(i) < -3)
            time_angle1b = time_angle1b + 0.1;
        end
        if (-10 < beta(i)) && ( beta(i) < -7)
            time_angle2b = time_angle2b + 0.1;
        end
        if (-13 < beta(i)) && ( beta(i) < -10)
            time_angle3b = time_angle3b + 0.1;
        end
        if (-17 < beta(i)) && ( beta(i) < -13)
            time_angle4b = time_angle4b + 0.1;
        end
     end
end
 score_angle1f = (time_angle1f/6)*100;
    if score_angle1f > 100
        score_angle1f = 100;     
    end
    score_angle2f = (time_angle2f/10)*100;
    if score_angle2f > 100
        score_angle2f = 100;     
    end
    score_angle3f = (time_angle3f/4)*100;
    if score_angle3f > 100
        score_angle3f = 100;     
    end
    score_angle4f = (time_angle4f/7)*100;
    if score_angle4f > 100
        score_angle4f = 100;     
    end
    score_angle1b = (time_angle1b/6)*100;
    if score_angle1b > 100
        score_angle1b = 100;     
    end
    score_angle2b = (time_angle2b/10)*100;
    if score_angle2b > 100
        score_angle2b = 100;     
    end
    score_angle3b = (time_angle3b/4)*100;
    if score_angle3b > 100
        score_angle3b = 100;     
    end
    score_angle4b = (time_angle4b/7)*100;
    if score_angle4b > 100
        score_angle4b = 100;     
    end
% Calculate score
deviation = abs(yuser - fitpath(xuser));
mean_dev = mean(deviation);
score = 100*(1-tanh(mean_dev-3))/2;
%trial and error to get a function which gives a good range of scores
%(worst case = 0%, no movement ~ 30%, perfect = 100%)
score = round(score,2,'significant');

right_score = (score_angle1r +score_angle2r +score_angle3r +score_angle4r)/4;
left_score = (score_angle1l +score_angle2l +score_angle3l +score_angle4l)/4;
front_score = (score_angle1f +score_angle2f +score_angle3f +score_angle4f)/4;
back_score = (score_angle1b +score_angle2b +score_angle3b +score_angle4b)/4;
right_score = round(right_score,2,'significant');
left_score = round(left_score,2,'significant');
front_score = round(front_score,2,'significant');
back_score = round(back_score,2,'significant');

% Figure showing user path compared to ideal path, angles
figure
subplot(3,1,1);
plot(xuser,yuser,'m','LineWidth',1)
hold on
plot(xpath+15,ypath,'k--','LineWidth',1)
xlim([15, 640]);
ylim([-8,12]);
legend('Player path','Ideal path','fontsize',8)
title(['Difficulty Level : ' difficulty '     Score = ' num2str(score) '%']);
xlabel('y');
ylabel('x');
hold off

subplot(3,1,2);
plot(timeuser,alpha,'k','LineWidth',1)
title(['Right/ Left angle       Right = ' num2str(right_score) '%    Left = ' num2str(left_score) '%'])
xlabel('Time (s)')
ylabel('Angle (degrees)')
ylim([-20, 20])
xlim([0,130]);

subplot(3,1,3);
plot(timeuser,beta,'k','LineWidth',1)
title(['Front/ Back angle       Front = ' num2str(front_score) '%    Back = ' num2str(back_score) '%'])
xlabel('Time (s)')
ylabel('Angle (degrees)')
ylim([-20, 20])
xlim([0,130]);

% calculate max angles
max_angle_right = max(alpha);
max_angle_left = min(alpha);
max_angle_forward = max(beta);
max_angle_backward = min(beta);




