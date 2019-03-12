
data = csvread('user_data.txt');

time = data(1:end,1);

alpha = data(1:end,2);

beta = data(1:end,3);

figure
subplot(2,1,1);
plot(time,alpha)
subplot(2,1,2);
plot(time,beta)

max_angle_left = max(alpha);
max_angle_right = min(alpha);
max_angle_forward = max(beta);
max_angle_backward = min(beta);


